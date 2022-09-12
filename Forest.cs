using System;

namespace StaticMembers
{
    class Forest
    {
        //fields
        public int age;

        public string biome;

        //Define a private static field
        private static int forestsCreated;
        private static string treeFacts;

        //constructors
         //This will add 1 to the property every time an object is constructed.
        public Forest(string name, string biome)
        {
            this.Name = name;
            this.Biome = biome;
            Age = 0;
            ForestsCreated++;
           
        }

        //second overloading constructor
        public Forest(string name) :this(name, "Unknown")
        {}

          //create a static constructor
      static Forest()
    {
      treeFacts ="Forests provide a diversity of ecosystem services including:\r\n  aiding in regulating climate.\r\n  purifying water.\r\n  mitigating natural hazards such as floods.\n";

     ForestsCreated=0;
    }

        //properties
        public string Name { get; set; }

        public int Trees { get; set; }

        //propertities with  set()validation
        public string Biome
        {
            get
            {
                return biome;
            }
            set{
              if(value =="Tropical" ||value=="Temperate" || value =="Boreal"){
                biome = value;
              }esle{
                biome ="Unknown";
              }
            }
        }

        public int Age{
          get {return age;}
          private set {age =value;}
        }

         //Define a public static property
         // public getter and private setter.
    public static int ForestsCreated
    {
      get {return forestsCreated; }
      private set{forestsCreated = value;}
    }
    //Define a public static property with get()
    public static string TreeFacts
    {
     get {return treeFacts;}
    }
        //Methods
        public int Grow(){
          Trees +=30;
          Age +=1;
          return Trees;
        }

        public int Burn(){
          Trees -=20;
          Age +=1;
          return Trees;
        }
       //Define a public static method
    public static void PrintTreeFacts(){
      Console.WriteLine(TreeFacts);
    }

    public static void PrintTreeFacts()
    {
      Console.WriteLine(TreeFacts);
    }
    

    }
}
