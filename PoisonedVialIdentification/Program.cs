namespace PoisonedVialIdentification
{
    // 1024 vials, exactly one is poisoned. 10 test animals, 24 hours for the poison to take effect.
    // Number the vials 0..1023 and give animal i a sip from every vial whose i-th binary digit is 1.
    // After 24 hours, the set of dead animals is exactly the binary representation of the poisoned vial's index.
    internal class Program
    {
        static void Main(string[] args)
        {
            const int animalCount = 10; // 2^10 = 1024 vials identifiable

            foreach (int poisonedVial in new[] { 0, 56, 511, 1023 })
            {
                bool[] assignment = AssignVialsToAnimals(poisonedVial, animalCount);
                int found = DecodePoisonedVial(assignment);

                Console.WriteLine(
                    $"Poisoned vial: {poisonedVial,4} | Dead animals: {FormatAssignment(assignment)} | Decoded: {found}");
            }
        }

        // Which animals drink from the poisoned vial (i.e. which animals end up dead).
        // Animal i drinks from vial v whenever bit i of v is set, so only bits set in the
        // poisoned index cause a death.
        public static bool[] AssignVialsToAnimals(int poisonedVial, int animalCount)
        {
            bool[] dead = new bool[animalCount];

            for (int animal = 0; animal < animalCount; animal++)
            {
                dead[animal] = (poisonedVial & (1 << animal)) != 0;
            }

            return dead;
        }

        // Reconstruct the poisoned vial's index from which animals died.
        public static int DecodePoisonedVial(bool[] deadAnimals)
        {
            int vial = 0;

            for (int animal = 0; animal < deadAnimals.Length; animal++)
            {
                if (deadAnimals[animal])
                {
                    vial |= 1 << animal;
                }
            }

            return vial;
        }

        private static string FormatAssignment(bool[] assignment)
        {
            char[] bits = new char[assignment.Length];

            for (int i = 0; i < assignment.Length; i++)
            {
                bits[assignment.Length - 1 - i] = assignment[i] ? '1' : '0';
            }

            return new string(bits);
        }
    }
}
