using Giorno_2;

Console.WriteLine("ciao");

Persona a = new()
{
    Name = "Jhon",
    Surname = "Benson",
    Age = 30,
};


a.getName(a.Name);
a.getSurname(a.Surname);
a.getDetails(a.Name, a.Surname, a.Age);


