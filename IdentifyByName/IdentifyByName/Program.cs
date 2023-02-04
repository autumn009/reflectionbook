int typeCount = 0;
int memberCount = 0;

foreach (var assem in AppDomain.CurrentDomain.GetAssemblies())
{
    foreach (var type in assem.GetTypes())
    {
        if (type.FullName != null && type.FullName.StartsWith("System.Reflection."))
        {
            if (type.IsPublic)
            {
                Console.WriteLine(type.FullName);
                typeCount++;

                foreach (var member in type.GetMembers())
                {
                    Console.WriteLine($"  {member.Name} ({member.MemberType})");
                    memberCount++;
                }
            }
        }
    }
}
Console.WriteLine($"type count={typeCount}");
Console.WriteLine($"member count={memberCount}");
