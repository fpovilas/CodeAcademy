namespace Task1.Class
{
    internal class ProgressBar
    {
        private int Progress { get; set; }

        public async Task<ProgressBar> StartProgressBar()
        {
            for (int i = 0; i <= 100; i++)
            {
                Progress = i;
                await Task.Delay(1000);
            }
            return new ProgressBar();
        }

        public async Task GetProgressInfo()
        {
            while(Progress < 100)
            { 
                Console.WriteLine(Progress);
                await Task.Delay(3000);
                Console.Clear();
            }
            Console.WriteLine(Progress);
        }

        public int GetProgress() => Progress;

        public void SetProgress(int val) => Progress = val;
    }
}
