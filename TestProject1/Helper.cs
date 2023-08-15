using System;
using System.Collections.Generic;
using System.Drawing;

namespace TestProject1 {
    static class Helper {
        static readonly Random rnd;
        
        static Helper() {
            rnd = new Random();
        }

        public static IEnumerable<Item> CreateItems(int count, Func<int, Color> getColor) {
            throw new InvalidOperationException();
        }
    }
}