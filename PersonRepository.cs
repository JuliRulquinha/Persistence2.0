using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;


namespace Persistence
{
    public class PersonRepository
    {

        SqlConnection Connection = new SqlConnection("Server=localhost;Database=Person;Trusted_Connection=True;");
        SqlCommand? command;
        public bool TestConnection()
        {
            
            try
            {
                Connection.Open();
                Console.WriteLine("It worked");
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public Person GetPersonBySSN(string SSN)
        {
            try
            {
                Connection.Open();

                string searchCommand = $"SELECT * FROM Person WHERE SSN like '{SSN}'";
                SqlCommand searchForPerson = Connection.CreateCommand();
                searchForPerson.CommandText = searchCommand;
                var reader = searchForPerson.ExecuteReader();

                Person p = new Person();

                while (reader.Read())
                {
                    p.name = reader["name"].ToString();
                    p.SSN = reader["SSN"].ToString();
                    p.id = Convert.ToInt32(reader["id"]);
                }

                return p;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;

        }
        public bool Save(Person p)
        {
            
            try
            {
                Connection.Open();

                string commandText = $"INSERT INTO Person(Name, SSN) VALUES('{p.name}','{p.SSN}') ";
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = commandText;
                var result = command.ExecuteNonQuery();

                if (result == 0)
                {
                    Console.WriteLine("The insertion command failed to excute.");

                }
                else
                {
                    Console.WriteLine($"Inserted items: {result}");
                }
          
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
            
        }

        public Person GetById(int id)
        {   

            try
            {
                Connection.Open();

                string commandText = $"SELECT * FROM Person WHERE id={id}";
                command = Connection.CreateCommand();
                command.CommandText = commandText;
                var output = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void UpdateById(int id, Person updatedPerson) 
        {
            try
            {
                Connection.Open();

                string commandText = $"UPDATE Person SET Name='{updatedPerson.name}', SSN='{updatedPerson.SSN}' WHERE id={id}";
                command = Connection.CreateCommand();
                command.CommandText = commandText;
                var result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void DeleteById(int id)
        {
            
            try
            {
                Connection.Open();

                string commandText = $"DELETE FROM Person WHERE id={id}";
                command = Connection.CreateCommand();
                command.CommandText = commandText;
                var numberOfRowsAffected = command.ExecuteNonQuery();

                if (numberOfRowsAffected == 0)
                {
                    Console.WriteLine("No records were deleted.");
                }
                else
                {
                    Console.WriteLine($"{numberOfRowsAffected} rows were affected.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

