using ReverseDAL;
namespace ReverseBL

{
    //Buisness Layer
    public class ReverseBLClass()
    {
        public string strReverseBL()
        {
            DALReverseString d = new DALReverseString();
            string beforeReverse = d.strReverseDAL();
            string afterReverse = new string(beforeReverse.Reverse().ToArray());
            return afterReverse;
        }

    }
    
}
