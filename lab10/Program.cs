namespace lab10
{

    public interface IRemove<T>
    {
        void Remove();
    }

    public interface ISet<T>
    {
        void Set(T item);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //GenericDemo();
            IList<string> names = new List<string>();
            names.Add("Adam");
            names.Add("Ewa");
            names.Add("Karol");
            Console.WriteLine(names[0]);
            Console.WriteLine(string.Join("\n", names));
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i].ToUpper());
            }

            Console.WriteLine("foreach:");

            foreach(string name in names)
            {
                Console.WriteLine(name.ToUpper());
            }

            string first = names[0];
            names.RemoveAt(0);
            names.Add(first);
            names.Insert(0, first);
            Console.WriteLine(string.Join(", ", names));
        }

        private static void GenericDemo()
        {
            //Node head = new Node() { Value = "Adam" };
            //head.Next = new Node() { Value = "Ewa" };
            //head.Next.Next = new Node() { Value = "Karol" };

            Node<string> node = new Node<string>() { Value = "abcd" };
            Node<int> nodeInt = new Node<int>() { Value = 1 };

            Box<Pizza> box = new Box<Pizza>() { Content = new favPizza() };
            Console.WriteLine(string.Join(", ", box.Content.Ingredients));
            Box<string> stringBox = new Box<string>();

            PizzaBox<Pizza> pizzaBox = new PizzaBox<Pizza>();
            PizzaBox<favPizza> myFavPizza = new PizzaBox<favPizza>();
            //pizzaBox = myFavPizza;
            Pizza[] pizzas = new Pizza[1];
            favPizza[] pepperonis = new favPizza[1];
            pizzas = pepperonis; //kowariancja
        }

        public class Box<T>: IRemove<T>, ISet<T>
        {
            public T? Content { get; set; }

            public void Remove()
            {
                Content = default(T);
            }

            public void Set(T item)
            {
                
            }
        }

        public class PizzaBox<T> : Box<T> where T: Pizza
        {

        }

        public abstract class Pizza
        {
            public abstract string[] Ingredients { get; }
        }

        public class favPizza : Pizza
        {
            public override string[] Ingredients => new string[] { "cheese", "pepperoni", "1", "2", "3" };
        }

        public class Node
        {
            public string Value { get; set; }
            public Node Next { get; set; }
        }

        public class NodeInt
        {
            public int Value { get; set; }
            public NodeInt Next { get; set; }
        }

        public class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
        }
    }
}