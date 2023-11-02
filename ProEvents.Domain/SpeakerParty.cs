using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEvents.Domain
{
    public class SpeakerParty
    {
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public int PartyId { get; set; }
        public Party Party { get; set; }
    }
}
