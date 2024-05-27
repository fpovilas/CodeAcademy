namespace Task4.Class
{
    internal class Circle : Shape
    {
        public int Diameter { get; set; } = 0;

        public override void Draw()
        {
            Console.WriteLine("""
                        , - ~ ~ ~ - ,
                    , '               ' ,
                  ,                       ,
                 ,                         ,
                ,                           ,
                ,                           ,
                ,                           ,
                 ,                         ,
                  ,                       ,
                    ,                  , '
                      ' - , _ _ _ ,  '
                """);
            Console.WriteLine($"Cricle diameter: {Diameter}");
        }
    }
}
