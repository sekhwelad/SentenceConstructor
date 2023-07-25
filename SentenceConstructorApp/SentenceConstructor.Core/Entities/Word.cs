using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceConstructor.Core.Entities
{
    public class Word : BaseEntity
    {
        public string Name { get; set; }
        public WordType WordType { get; set; }
        public int WordTypeId { get; set; }
    }
}
