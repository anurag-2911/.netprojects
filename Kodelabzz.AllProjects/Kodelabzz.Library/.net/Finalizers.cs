namespace Kodelabzz.Library.net
{
    public class Finalizers
    {
        private int index = 0;

        public Finalizers()
        {

        }
      

        public Finalizers(int value)
        {
            this.index = value;
            //Console.WriteLine("constructed object : {0} in generation {1} ",this.index,GC.GetGeneration(this));
        }

        ~Finalizers()
        {
            Thread.Sleep(500);
           Console.WriteLine("finalizing object : {0} from generation {1}",this.index,GC.GetGeneration(this));
        }
    }
}
