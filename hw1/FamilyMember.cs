using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    enum Gender { Male, Female }
    class FamilyMember
    {
        public string? Name { get; set; }
        public Gender gender { get; set; }
        public FamilyMember[]? Children { get; set; }
        public FamilyMember? Mother { get; set; }
        public FamilyMember? Father { get; set; }

        public FamilyMember()
        {
        }

        public FamilyMember(string name, Gender gender, FamilyMember mother, FamilyMember father, params FamilyMember[] children)
        {
            this.Name = name;
            this.gender = gender;
            this.Mother = mother;
            this.Father = father;
            this.Children = children;
        }

        public FamilyMember FindOldMather(FamilyMember member)
        {
            while (member.Mother != null)
            {
                member = member.Mother;
            }
            return member;
        }
        public void MotherInFamaly()
        {
            FamilyMember adult = this;
            if (adult.Mother != null)
            {
                adult = adult.Children[0]?.Mother;

            }
            adult = FindOldMather(adult);


            Console.WriteLine($"{adult.Name} --> ");

            bool femaleChild = true;
            while (true)
            {
                femaleChild = false;
                Console.WriteLine($"{adult.Name} --> ");

                foreach (FamilyMember child in adult.Children)
                {
                    if (child.gender == Gender.Female)
                    {
                        adult = child;
                        femaleChild = true;
                        break;
                    }
                }

            }




        }

        public void ShowThree()
        {
            List<List<FamilyMember>> levels = new List<List<FamilyMember>>();
            List<FamilyMember> currentLevel = new List<FamilyMember> { this };
          
            do {
                List<FamilyMember> level = new List<FamilyMember>();
                List<FamilyMember> tmpCurrentlevel = new List<FamilyMember>();
                foreach (FamilyMember mem in currentLevel)
                {
                    if (mem.Children != null)
                    {
                        foreach (FamilyMember child in mem.Children)
                        {
                            if (child.Mother != null)
                            {
                                if (!level.Contains(child.Mother))
                                {
                                    level.Add(child.Mother);
                                }
                            }
                            if (child.Father != null)
                            {
                                if (!level.Contains(child.Father))
                                {
                                    level.Add(child.Father);
                                }
                            }
                            tmpCurrentlevel.Add(child);

                        }
                    }
                    else
                    {
                        level.Add(mem);
                    }
                }
                
                levels.Add(level);
                currentLevel = tmpCurrentlevel;
            } 
            while (currentLevel.Count > 0);
            
            PrintTree( levels );

        }

        private void PrintTree(List<List<FamilyMember>> levels)
        {
            foreach (List<FamilyMember> level in levels)
            {

                foreach (FamilyMember member in level)
                {
                    Console.Write($"{member.Name} ");
                }
                Console.WriteLine();
            }
        }
       


       
    }
}
