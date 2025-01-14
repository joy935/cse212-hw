/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Enqueue one customer and serve the customer
        // Expected Result: It should display the customer information
        Console.WriteLine("Test 1");
        var cs = new CustomerService(2);
        cs.AddNewCustomer();
        cs.ServeCustomer();

        // Defect(s) Found: check if the queue is empty before serving

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Serve a customer in the right order
        // Expected Result: It should serve a customer and remove them from the queue
        Console.WriteLine("Test 3");
        cs = new CustomerService(3);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine(cs);
        cs.ServeCustomer();
        Console.WriteLine(cs);

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Respect the max queue size
        // Expected Result: It should display an error message when the queue is full (maxSize = 2)
        Console.WriteLine("Test 2");
        cs = new CustomerService(2);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine(cs);        

        // Defect(s) Found: doesn't recognize that the queue is full. Change > to >= in AddNewCustomer

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Serve a customer from an empty queue
        // Expected Result: It should display an error message
        Console.WriteLine("Test 4");
        cs = new CustomerService(2);
        cs.ServeCustomer();

        // Defect(s) Found: doesn't recognize that the queue is empty. Check if the queue is empty before serving

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    } 

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in Queue.");
        } else {
            var customer = _queue[0];
            Console.WriteLine(customer);
            _queue.RemoveAt(0);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}