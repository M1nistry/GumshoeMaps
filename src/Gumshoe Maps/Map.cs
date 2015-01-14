﻿using System;
using System.Collections.Generic;

namespace Gumshoe_Maps
{
    internal class Map : IEquatable<Map>
    {
        public int Id { get; set; }
        public string Rarity { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int Quality { get; set; }
        public int Quantity { get; set; }
        public List<string> Affixes { get; set; }

        public bool Equals(Map other)
        {
            return other.Id == Id;
        }
    }
}
