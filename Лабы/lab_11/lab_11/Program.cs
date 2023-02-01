namespace lab_11
{
    internal class Program
    {
        static void Main( string[] args )
        {
            
            File.WriteAllText("Reflection.txt", string.Empty);

            Reflector.NameWrite("lab_11.Reflector");
            Reflector.PublicMethodsEnumerationWrite("lab_11.Reflector");
            Reflector.FieldsAndPropsWrite("lab_11.Reflector");

        
           // Reflector.Create(5, 6);
           
        }
    }
}
