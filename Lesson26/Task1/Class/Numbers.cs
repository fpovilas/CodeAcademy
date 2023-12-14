namespace Task1.Class
{
    internal class Numbers
    {
        private List<int> Nums { get; set; } = new ();

        public void AddNumber(int num)
        {
            Nums.Add(num);
        }

        public void GetNumbers()
        {
            foreach (int num in Nums)
            {
                Console.WriteLine(num);
            }
        }
    }
}
