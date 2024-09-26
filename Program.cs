namespace Persistence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonRepository personRepository = new PersonRepository();
            //personRepository.TestConnection();

            Person person = new Person();
            person.name = "Juli";
            person.SSN = "19273248748";


            Person person2 = new Person();
            person2.name = "Marcele";
            person2.SSN = "10043311776";
          

            //var person = personRepository.GetPersonBySSN("19273248748");
            personRepository.DeleteById(2);

           
        }
    }
}
