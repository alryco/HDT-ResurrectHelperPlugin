using System.Runtime.CompilerServices;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace ResurrectHelper
{
    public static class RelevantCards
    {
        static RelevantCards()
        {
            NzothTheCorruptor = Database.GetCardFromId("OG_133");
            Resurrect = Database.GetCardFromId("BRM_017");
            OnyxBishop = Database.GetCardFromId("KAR_204");
        }

        public static Card NzothTheCorruptor { get; }
        public static Card Resurrect { get; }
        public static Card OnyxBishop { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNzoth(this Card card) => card.Id == NzothTheCorruptor.Id;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsResurrect(this Card card) => card.Id == Resurrect.Id;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOnyxBishop(this Card card) => card.Id == OnyxBishop.Id;
    }
}
