using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge2_GeneticAlgorithm
{
    // Chromosome contract
    public interface IChromosome<TGene, TFitness> :
        IComparable<IChromosome<TGene, TFitness>>
        where TFitness : IComparable<TFitness>
    {
        IReadOnlyList<TGene> Genes { get; }
        TFitness Fitness { get; }
        IChromosome<TGene, TFitness> Crossover(IChromosome<TGene, TFitness> other);
        void Mutate(double mutationRate);
    }

    // Variance demo
    public interface ISelectionStrategy<in TChromosome, out TResult>
    {
        IEnumerable<TResult> Select(IEnumerable<TChromosome> population, int count);
    }

    public interface ICrossoverStrategy<in TParent, out TChild>
    {
        TChild Crossover(TParent p1, TParent p2);
    }

    public class EvolutionaryAlgorithm<TGene, TFitness, TChromosome>
        where TChromosome : class, IChromosome<TGene, TFitness>
        where TFitness : struct, IComparable<TFitness>
    {
        private List<TChromosome> _population;
        private ConcurrentBag<TChromosome> _offspring = new();

        public EvolutionaryAlgorithm(IEnumerable<TChromosome> seedPopulation)
        {
            _population = seedPopulation.ToList();
        }

        public async Task<TChromosome> EvolveAsync(
            int generations,
            double mutationRate,
            CancellationToken token)
        {
            for (int g = 0; g < generations; g++)
            {
                token.ThrowIfCancellationRequested();

                await Parallel.ForEachAsync(_population, token,
                    async (chromosome, ct) =>
                    {
                        await Task.Yield(); // simulate evaluation
                    });

                _offspring = new ConcurrentBag<TChromosome>();

                Parallel.For(0, _population.Count / 2, i =>
                {
                    var parent1 = _population[i];
                    var parent2 = _population[_population.Count - 1 - i];

                    var child = (TChromosome)parent1.Crossover(parent2);
                    child.Mutate(mutationRate);
                    _offspring.Add(child);
                });

                _population = _offspring.ToList();
            }

            return _population.OrderByDescending(c => c.Fitness).First();
        }

        // Parallel aggregate statistics
        public TFitness GetBestFitness()
        {
            return _population
                .AsParallel()
                .Max(c => c.Fitness);
        }
    }

    // Simple concrete chromosome
    public class IntChromosome : IChromosome<int, double>
    {
        private static Random _rand = new();

        public IReadOnlyList<int> Genes { get; }
        public double Fitness => Genes.Sum();

        public IntChromosome(int size)
        {
            Genes = Enumerable.Range(0, size)
                .Select(_ => _rand.Next(0, 10))
                .ToList();
        }

        public int CompareTo(IChromosome<int, double> other)
            => Fitness.CompareTo(other.Fitness);

        public IChromosome<int, double> Crossover(IChromosome<int, double> other)
        {
            var childGenes = Genes.Zip(other.Genes,
                (g1, g2) => _rand.NextDouble() > 0.5 ? g1 : g2).ToList();

            return new IntChromosome(childGenes.Count);
        }

        public void Mutate(double rate) { }
    }

    class Program
    {
        static async Task Main()
        {
            var population = Enumerable.Range(0, 20)
                .Select(_ => new IntChromosome(5))
                .ToList();

            var engine = new EvolutionaryAlgorithm<int, double, IntChromosome>(population);

            var best = await engine.EvolveAsync(10, 0.1, CancellationToken.None);

            Console.WriteLine("Best Fitness: " + best.Fitness);
        }
    }
}
