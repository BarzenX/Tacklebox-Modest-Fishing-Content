namespace Tacklebox.Items._Global
{
    internal class JigID
    {
        public const short SeaJig = 1;
        public const short SnowJig = 2;
        public const short JungleJig = 4;
        public const short HellJig = 8;
        public const short CoinHook = 16;

        /// <summary>
        /// Checks if the stated jig is set in the given variable
        /// </summary>
        /// <param name="jigVariable"></param>
        /// <param name="jigID"></param>
        /// <returns></returns>
        public static bool CheckJig (int jigVariable, short jigID)
        { 
            return (jigVariable & jigID) == jigID;
        }
    }
}
