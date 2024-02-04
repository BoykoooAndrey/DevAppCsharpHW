using hw1;

class Program
{
    public static void Main()
    {
        FamilyMember grandfather = new() { Mother = null, Father = null, Name = "Дедушка", gender = Gender.Male };
        FamilyMember grandmother = new() { Mother = null, Father = null, Name = "Бабушка", gender = Gender.Female };
        FamilyMember father = new FamilyMember() { Mother = grandmother, Father = grandfather, Name = "Папа", gender = Gender.Male };
        FamilyMember brother = new FamilyMember() { Mother = grandmother, Father = grandfather, Name = "Брат", gender = Gender.Male };
        grandfather.Children = new FamilyMember[] { father, brother };
        FamilyMember mother = new FamilyMember() { Mother = null, Father = null, Name = "Мама", gender = Gender.Female };
        FamilyMember mother2 = new FamilyMember() { Father = null, Mother = null, Name = "Мама2", gender = Gender.Female };
        FamilyMember son = new FamilyMember() { Mother = mother, Father = father, Name = "Сын", gender = Gender.Male };
        FamilyMember son2 = new FamilyMember() { Father = father, Mother = mother2, Name = "Сын2", gender = Gender.Male };
        mother2.Children = new FamilyMember[] { son2 };
        

        mother.Children = new FamilyMember[] { son };
        father.Children = new FamilyMember[] { son, son2 };



        grandfather.ShowThree();

    }

}