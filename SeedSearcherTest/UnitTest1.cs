using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeedSearcherGui;

namespace SeedSearcherTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Fixed1_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 26, 16, 6, 10, 3, 1, 1, 19, 0, 1, 0, 0, false, false, 0);
            searcher.RegisterPokemon2(1, 31, 9, 3, 23, 22, 1, 0, 19, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(9, 2, 5, 26, 19, 31, 1, 1, 16, 3, 3, 0, 0, false, false);
            int[] target = { 26, 16, 6, 10, 3, 11 };
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x82a2b175229d6a5bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(24, 17, 29, 31, 19, 4, 1, 1, 5, 4, 1, 0, 0, false, false, 3);
            searcher.RegisterPokemon2(11, 15, 25, 22, 6, 31, 1, 1, 8, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(29, 18, 31, 30, 19, 29, 1, 1, 6, 2, 3, 0, 0, false, false);
            int[] target = { 24, 17, 29, 19, 4, 31 };
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa8ac5d48a75a96cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 6, 21, 20, 31, 4, 1, 1, 1, 5, 1, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(31, 16, 3, 13, 8, 11, 1, 0, 6, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 16, 23, 21, 1, 27, 1, 0, 9, 0, 3, 0, 0, false, false);
            int[] target = { 7, 6, 21, 20, 4, 7 };
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb7588e9bd6e9b977ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 8, 5, 18, 22, 27, 1, 1, 4, 0, 1, 0, 0, false, false, 0);
            searcher.RegisterPokemon2(30, 17, 22, 31, 0, 19, 1, 0, 24, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 25, 31, 29, 25, 15, 1, 1, 0, 2, 3, 0, 0, false, false);
            int[] target = { 8, 5, 18, 22, 27, 29 };
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfbde94815ae686b5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 4, 7, 14, 31, 14, 1, 1, 3, 5, 1, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(22, 31, 4, 20, 24, 8, 1, 1, 9, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(19, 31, 25, 5, 2, 17, 1, 0, 2, 1, 3, 0, 0, false, false);
            int[] target = { 20, 4, 7, 14, 14, 27 };
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd6f8e019764ab5bbul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(20, 16, 31, 13, 31, 20, 1, 0, 8, 5, 1, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(31, 13, 21, 3, 12, 2, 1, 0, 16, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 31, 25, 10, 27, 19, 1, 1, 22, 1, 3, 0, 0, false, false);
            int[] target = { 20, 16, 31, 13, 20, 6 };
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x56c57c9f861283eeul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(14, 19, 29, 31, 12, 7, 1, 0, 9, 4, 1, 0, 0, false, false, 3);
            searcher.RegisterPokemon2(8, 18, 31, 25, 1, 27, 1, 0, 24, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(24, 31, 17, 29, 26, 16, 1, 1, 21, 1, 3, 0, 0, false, false);
            int[] target = { 14, 19, 29, 12, 7, 28 };
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x726bc1c2727c889ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(17, 20, 2, 31, 18, 24, 1, 0, 3, 4, 1, 0, 0, false, false, 3);
            searcher.RegisterPokemon2(10, 7, 4, 30, 2, 31, 1, 1, 22, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 2, 31, 3, 21, 1, 1, 0, 3, 2, 3, 0, 0, false, false);
            int[] target = { 17, 20, 2, 18, 24, 30 };
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x13b9d7a98177a652ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(8, 8, 25, 31, 25, 28, 1, 1, 23, 4, 1, 0, 0, false, false, 3);
            searcher.RegisterPokemon2(26, 1, 9, 23, 21, 31, 1, 1, 10, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(17, 0, 31, 28, 5, 20, 1, 1, 14, 2, 3, 0, 0, false, false);
            int[] target = { 8, 8, 25, 25, 28, 5 };
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf96a9e219cd4b8f2ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(24, 4, 31, 17, 19, 8, 1, 1, 5, 2, 1, 0, 0, false, false, 2);
            searcher.RegisterPokemon2(22, 31, 1, 26, 20, 28, 1, 1, 6, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 19, 3, 9, 27, 31, 1, 0, 2, 3, 3, 0, 0, false, false);
            int[] target = { 24, 4, 17, 19, 8, 3 };
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2aee4d78c82594a5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 24, 12, 13, 31, 27, 1, 0, 12, 5, 1, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(8, 31, 17, 7, 22, 19, 1, 1, 3, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(11, 28, 23, 19, 6, 31, 1, 1, 16, 3, 3, 0, 0, false, false);
            int[] target = { 20, 24, 12, 13, 27, 24 };
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3f701fcc7031b7edul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(25, 14, 3, 31, 10, 31, 1, 0, 6, 3, 1, 0, 0, false, false, 5);
            searcher.RegisterPokemon2(29, 31, 7, 10, 10, 10, 1, 0, 21, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 16, 6, 15, 30, 31, 1, 1, 19, 3, 3, 0, 0, false, false);
            int[] target = { 25, 14, 3, 31, 10, 2 };
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x286af6a95a11b890ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 8, 18, 11, 15, 27, 1, 0, 6, 0, 1, 0, 0, false, false, 0);
            searcher.RegisterPokemon2(31, 26, 5, 30, 12, 9, 1, 0, 7, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(26, 2, 14, 0, 20, 31, 1, 1, 13, 3, 3, 0, 0, false, false);
            int[] target = { 8, 18, 11, 15, 27, 20 };
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xe1b27e774ba7d1d2ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(24, 29, 26, 30, 31, 30, 1, 1, 0, 5, 1, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(20, 11, 1, 30, 3, 31, 1, 0, 13, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(12, 26, 31, 31, 10, 27, 1, 1, 19, 2, 3, 0, 0, false, false);
            int[] target = { 24, 29, 26, 30, 30, 23 };
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x334dd445c9daa3bcul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(17, 19, 31, 8, 31, 31, 1, 1, 22, 5, 1, 0, 0, false, false, 2);
            searcher.RegisterPokemon2(15, 28, 21, 18, 7, 31, 1, 0, 22, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(1, 21, 23, 31, 19, 13, 1, 1, 4, 4, 3, 0, 0, false, false);
            int[] target = { 17, 19, 8, 31, 31, 9 };
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xc77f0cf6d9541637ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(18, 31, 29, 3, 6, 3, 1, 0, 23, 1, 1, 0, 0, false, false, 1);
            searcher.RegisterPokemon2(18, 4, 31, 31, 31, 5, 1, 1, 22, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 6, 4, 24, 6, 1, 1, 14, 1, 3, 0, 0, false, false);
            int[] target = { 18, 29, 3, 6, 3, 18 };
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x821ce3932db7830cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(15, 14, 30, 3, 31, 16, 1, 0, 18, 5, 1, 0, 0, false, false, 4);
            searcher.RegisterPokemon2(30, 30, 19, 2, 2, 31, 1, 0, 6, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 26, 16, 27, 18, 27, 1, 0, 16, 0, 3, 0, 0, false, false);
            int[] target = { 15, 14, 30, 3, 16, 2 };
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd97e2594f806755cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 7, 26, 7, 1, 31, 1, 0, 6, 3, 1, 0, 0, false, false, 5);
            searcher.RegisterPokemon2(31, 8, 4, 13, 6, 9, 1, 0, 2, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(24, 31, 30, 22, 21, 31, 1, 1, 9, 3, 3, 0, 0, false, false);
            int[] target = { 28, 7, 26, 7, 1, 24 };
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4d3b77e582afdc3bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 30, 9, 31, 10, 1, 1, 0, 9, 4, 1, 0, 0, false, false, 3);
            searcher.RegisterPokemon2(27, 9, 31, 17, 3, 29, 1, 0, 6, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 14, 25, 13, 31, 13, 1, 1, 16, 5, 3, 0, 0, false, false);
            int[] target = { 7, 30, 9, 10, 1, 24 };
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x690631d596db0e5bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 11, 4, 21, 6, 2, 1, 0, 7, 0, 1, 0, 0, false, false, 0);
            searcher.RegisterPokemon2(24, 2, 13, 23, 21, 31, 1, 1, 23, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(5, 10, 31, 2, 26, 15, 1, 0, 11, 2, 3, 0, 0, false, false);
            int[] target = { 11, 4, 21, 6, 2, 4 };
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb59ffd2840b37d28ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed1_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star12);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(1, 1, 31, 21, 15, 31, 1, 0, 8, 2, 1, 0, 0, false, false, 5);
            searcher.RegisterPokemon2(21, 31, 28, 1, 31, 28, 1, 0, 4, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon3(9, 30, 5, 12, 29, 31, 1, 0, 19, 3, 3, 0, 0, false, false);
            int[] target = { 1, 1, 31, 21, 15, 12 };
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x15299cc85208cb6bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(23, 31, 22, 31, 4, 14, 2, 1, 7, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(14, 31, 19, 31, 31, 22, 3, 1, 20, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 5, 26, 19, 31, 2, 1, 16, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 17, 29, 31, 19, 4, 2, 1, 5, 0, 3, 0, 0, false, false);
            int[] target = { 23, 22, 4, 14, 19, 22 };
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x54562ea453ad4b6ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(18, 30, 31, 19, 29, 31, 2, 1, 6, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(29, 29, 31, 31, 10, 31, 3, 0, 5, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 6, 3, 0, 31, 12, 2, 0, 2, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 22, 30, 31, 30, 6, 2, 0, 3, 0, 3, 0, 0, false, false);
            int[] target = { 18, 30, 19, 29, 29, 10 };
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfd028becfb07e22ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(7, 31, 14, 31, 16, 17, 2, 1, 6, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 17, 31, 29, 29, 3, 1, 16, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(26, 31, 2, 31, 23, 9, 2, 0, 21, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(21, 6, 31, 20, 31, 9, 2, 0, 18, 2, 3, 0, 0, false, false);
            int[] target = { 7, 14, 16, 17, 29, 29 };
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x1fa0517d9f60fc44ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(30, 11, 10, 31, 31, 29, 2, 1, 1, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(29, 17, 31, 31, 31, 11, 3, 1, 1, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 17, 25, 6, 21, 2, 0, 17, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(10, 31, 31, 27, 13, 30, 2, 1, 19, 1, 3, 0, 0, false, false);
            int[] target = { 30, 11, 10, 29, 17, 11 };
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x5ee0f478de22f4ccul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(17, 31, 31, 17, 0, 30, 2, 0, 19, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 30, 6, 1, 3, 1, 17, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 5, 7, 19, 31, 9, 2, 1, 13, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(16, 31, 4, 5, 11, 31, 2, 1, 3, 3, 3, 0, 0, false, false);
            int[] target = { 17, 17, 0, 30, 6, 1 };
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x84eaa04c62e02131ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 3, 31, 31, 5, 31, 2, 1, 17, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 24, 31, 3, 1, 0, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 15, 6, 22, 29, 2, 1, 13, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 29, 22, 31, 31, 6, 2, 0, 22, 4, 3, 0, 0, false, false);
            int[] target = { 7, 3, 5, 31, 31, 24 };
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x624cdabbbe87070dul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 14, 24, 3, 31, 12, 2, 1, 13, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 12, 21, 31, 31, 29, 3, 1, 17, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 20, 31, 31, 26, 1, 2, 1, 4, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 11, 31, 31, 23, 23, 2, 0, 8, 4, 3, 0, 0, false, false);
            int[] target = { 14, 24, 3, 12, 21, 29 };
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x92e14c63cdb9dcdeul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(17, 31, 31, 11, 16, 31, 2, 1, 10, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(16, 31, 19, 31, 16, 31, 3, 1, 16, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 31, 31, 25, 23, 18, 2, 0, 23, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 13, 10, 12, 6, 2, 1, 20, 1, 3, 0, 0, false, false);
            int[] target = { 17, 31, 11, 16, 19, 16 };
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x93a6281788666576ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(1, 31, 7, 5, 31, 17, 2, 0, 1, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(17, 31, 30, 2, 31, 31, 3, 1, 1, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 27, 5, 31, 31, 14, 2, 0, 1, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(3, 31, 3, 31, 9, 18, 2, 0, 24, 4, 3, 0, 0, false, false);
            int[] target = { 1, 7, 5, 17, 30, 2 };
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x83a24c943feb3faul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 15, 22, 31, 20, 12, 2, 0, 21, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 12, 10, 31, 31, 3, 3, 1, 21, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 6, 27, 31, 13, 29, 2, 1, 18, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(17, 31, 25, 4, 31, 11, 2, 0, 18, 1, 3, 0, 0, false, false);
            int[] target = { 15, 22, 20, 12, 10, 3 };
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x14b14d18f75b1adcul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(6, 7, 31, 11, 31, 7, 2, 0, 5, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(7, 0, 31, 31, 31, 18, 3, 1, 5, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(1, 0, 27, 31, 0, 31, 2, 1, 17, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 7, 8, 25, 24, 2, 0, 19, 1, 3, 0, 0, false, false);
            int[] target = { 6, 7, 11, 7, 0, 18 };
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa8fd69c103600a8ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(15, 31, 7, 12, 28, 31, 2, 0, 1, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 31, 24, 25, 31, 31, 3, 1, 18, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(7, 9, 0, 28, 31, 31, 2, 0, 11, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 28, 15, 21, 31, 20, 2, 1, 17, 5, 3, 0, 0, false, false);
            int[] target = { 15, 7, 12, 28, 24, 25 };
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x53751c53bd979d5dul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(19, 31, 25, 31, 13, 16, 2, 0, 11, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(16, 31, 6, 31, 24, 31, 3, 1, 8, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(5, 20, 31, 28, 5, 31, 2, 0, 8, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 20, 28, 29, 31, 31, 2, 1, 4, 5, 3, 0, 0, false, false);
            int[] target = { 19, 25, 13, 16, 6, 24 };
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb7cf469b8a6798e6ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 0, 22, 28, 17, 2, 1, 13, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 17, 15, 31, 25, 3, 1, 22, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 27, 31, 12, 8, 28, 2, 1, 24, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 15, 31, 0, 27, 16, 2, 0, 13, 0, 3, 0, 0, false, false);
            int[] target = { 0, 22, 28, 17, 15, 25 };
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x10207681e9e97bc1ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(21, 28, 11, 3, 31, 31, 2, 1, 3, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(3, 5, 20, 31, 31, 31, 3, 1, 13, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 26, 18, 10, 0, 31, 2, 0, 23, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 5, 22, 23, 31, 30, 2, 1, 10, 5, 3, 0, 0, false, false);
            int[] target = { 21, 28, 11, 3, 5, 20 };
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x650bfc1ceee96b61ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(12, 12, 10, 31, 31, 17, 2, 1, 21, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(17, 15, 31, 31, 31, 1, 3, 1, 8, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(7, 31, 2, 28, 24, 31, 2, 1, 4, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(9, 23, 31, 16, 0, 31, 2, 0, 17, 2, 3, 0, 0, false, false);
            int[] target = { 12, 12, 10, 17, 15, 1 };
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2c5bda741ea73135ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(29, 4, 2, 16, 31, 31, 2, 1, 18, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(16, 31, 31, 13, 31, 31, 3, 0, 10, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(5, 14, 3, 6, 31, 31, 2, 1, 21, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 13, 31, 31, 29, 27, 2, 0, 9, 2, 3, 0, 0, false, false);
            int[] target = { 29, 4, 2, 16, 31, 13 };
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x44f821de88c5c479ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 31, 14, 13, 7, 2, 1, 10, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 7, 27, 3, 31, 3, 0, 10, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 12, 17, 31, 19, 2, 0, 17, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 14, 31, 30, 30, 30, 2, 0, 15, 2, 3, 0, 0, false, false);
            int[] target = { 31, 14, 13, 7, 27, 3 };
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x26de85077fa1dbeeul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(25, 31, 4, 13, 31, 17, 2, 1, 16, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(17, 31, 31, 14, 31, 31, 3, 1, 20, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(30, 28, 31, 25, 31, 6, 2, 0, 22, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(30, 31, 13, 23, 31, 3, 2, 0, 6, 5, 3, 0, 0, false, false);
            int[] target = { 25, 4, 13, 17, 31, 14 };
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4a860d971391cd78ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 2, 31, 10, 1, 19, 2, 1, 15, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 19, 7, 5, 3, 1, 21, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(19, 16, 9, 31, 3, 31, 2, 1, 18, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 26, 10, 31, 13, 26, 2, 1, 3, 4, 3, 0, 0, false, false);
            int[] target = { 2, 10, 1, 19, 7, 5 };
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x617cb39b6b34ebc8ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 31, 1, 13, 31, 27, 2, 0, 1, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(27, 31, 30, 1, 31, 31, 3, 0, 15, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(30, 31, 8, 31, 31, 23, 2, 1, 13, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(4, 15, 30, 31, 3, 31, 2, 0, 17, 3, 3, 0, 0, false, false);
            int[] target = { 20, 1, 13, 27, 30, 1 };
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x6d29e7673b6d073dul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 7, 22, 26, 31, 5, 2, 0, 7, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 5, 31, 20, 31, 16, 3, 1, 9, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(19, 9, 16, 16, 31, 31, 2, 0, 21, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 21, 31, 26, 10, 10, 2, 1, 23, 0, 3, 0, 0, false, false);
            int[] target = { 7, 22, 26, 5, 20, 16 };
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x7b32976d34d6e719ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 24, 14, 10, 23, 31, 2, 0, 19, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 23, 31, 0, 25, 31, 3, 1, 8, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(9, 31, 31, 22, 26, 28, 2, 1, 10, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 27, 23, 13, 24, 2, 0, 2, 0, 3, 0, 0, false, false);
            int[] target = { 24, 14, 10, 23, 0, 25 };
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4778a2721faab5adul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(15, 25, 22, 31, 6, 31, 2, 1, 8, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(22, 31, 6, 31, 1, 31, 3, 1, 8, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 30, 31, 19, 29, 31, 2, 1, 6, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 6, 3, 0, 31, 12, 2, 0, 2, 5, 3, 0, 0, false, false);
            int[] target = { 15, 25, 22, 6, 1, 9 };
            target[5] = -1;
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x8d2d7749ad1313c7ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 6, 3, 0, 31, 12, 2, 0, 2, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 0, 12, 31, 31, 22, 3, 1, 7, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 22, 30, 31, 30, 6, 2, 0, 3, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(16, 10, 31, 31, 17, 3, 2, 1, 9, 2, 3, 0, 0, false, false);
            int[] target = { 6, 3, 0, 12, 22, 9 };
            target[5] = -1;
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9272da33f24de87dul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 24, 31, 17, 31, 12, 2, 1, 22, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 17, 31, 12, 31, 7, 3, 0, 17, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 21, 11, 31, 3, 29, 2, 0, 7, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(17, 18, 31, 19, 31, 10, 2, 0, 19, 5, 3, 0, 0, false, false);
            int[] target = { 28, 24, 17, 12, 7, 22 };
            target[5] = -1;
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xcc6e1a44ebd50c4ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(10, 31, 31, 27, 13, 30, 2, 1, 19, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(13, 31, 31, 31, 30, 15, 3, 0, 18, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 23, 7, 17, 31, 31, 2, 0, 23, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(12, 31, 31, 10, 21, 8, 2, 0, 4, 1, 3, 0, 0, false, false);
            int[] target = { 10, 27, 13, 30, 15, 8 };
            target[5] = -1;
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x64265763235dc982ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(6, 8, 31, 31, 6, 11, 2, 0, 9, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 6, 31, 31, 11, 0, 3, 0, 17, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 14, 9, 31, 5, 31, 2, 0, 17, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(20, 31, 29, 31, 25, 4, 2, 0, 6, 1, 3, 0, 0, false, false);
            int[] target = { 6, 8, 6, 11, 0, 22 };
            target[5] = -1;
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x35d9d492546daa87ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(23, 31, 21, 13, 31, 20, 2, 0, 21, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(13, 31, 20, 22, 31, 31, 3, 1, 19, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(21, 31, 17, 1, 31, 27, 2, 1, 13, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(8, 8, 22, 18, 31, 31, 2, 1, 3, 3, 3, 0, 0, false, false);
            int[] target = { 23, 21, 13, 20, 22, 21 };
            target[5] = -1;
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9c481accb80e2adful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 13, 20, 31, 6, 2, 1, 18, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 20, 6, 27, 31, 31, 3, 0, 2, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 21, 3, 12, 2, 31, 2, 0, 16, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(25, 31, 10, 27, 31, 19, 2, 1, 22, 5, 3, 0, 0, false, false);
            int[] target = { 31, 13, 20, 6, 27, 8 };
            target[5] = -1;
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x56c57c9f861283eeul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 22, 11, 25, 27, 31, 2, 1, 8, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 25, 27, 31, 17, 31, 3, 1, 4, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 9, 18, 25, 2, 2, 1, 16, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 16, 1, 31, 2, 26, 2, 1, 5, 4, 3, 0, 0, false, false);
            int[] target = { 22, 11, 25, 27, 17, 19 };
            target[5] = -1;
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd507d539c1b7631ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 14, 12, 30, 16, 31, 2, 1, 2, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 30, 16, 27, 31, 31, 3, 1, 11, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(30, 31, 31, 1, 29, 20, 2, 1, 19, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(19, 21, 31, 31, 31, 13, 2, 1, 6, 4, 3, 0, 0, false, false);
            int[] target = { 14, 12, 30, 16, 27, 1 };
            target[5] = -1;
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x79a1a3080d80d21ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 27, 31, 25, 31, 2, 0, 2, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 25, 31, 28, 31, 3, 0, 16, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(17, 10, 31, 6, 31, 28, 2, 1, 5, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 31, 31, 9, 22, 28, 2, 0, 22, 1, 3, 0, 0, false, false);
            int[] target = { 31, 27, 31, 25, 28, 22 };
            target[5] = -1;
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4836f1443738f67eul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(5, 3, 31, 3, 4, 31, 2, 0, 20, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(3, 4, 31, 31, 28, 31, 3, 0, 20, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 13, 31, 1, 10, 30, 2, 0, 15, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 14, 28, 16, 19, 2, 0, 7, 0, 3, 0, 0, false, false);
            int[] target = { 5, 3, 3, 4, 28, 18 };
            target[5] = -1;
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x6209570ba3566dd7ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(12, 10, 26, 17, 31, 31, 2, 1, 5, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 17, 31, 1, 31, 31, 3, 0, 21, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 8, 31, 29, 31, 31, 2, 1, 12, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(22, 31, 4, 1, 31, 11, 2, 0, 6, 5, 3, 0, 0, false, false);
            int[] target = { 12, 10, 26, 17, 1, 0 };
            target[5] = -1;
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x571e6e87283343c3ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(18, 31, 31, 13, 31, 14, 2, 0, 23, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 14, 28, 31, 3, 0, 2, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 31, 21, 16, 31, 24, 2, 0, 23, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(3, 23, 31, 5, 3, 31, 2, 0, 1, 2, 3, 0, 0, false, false);
            int[] target = { 18, 13, 31, 14, 28, 22 };
            target[5] = -1;
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x49f5a6a9c5f30364ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 25, 4, 8, 7, 2, 1, 11, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 8, 7, 31, 5, 3, 1, 11, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 2, 8, 27, 10, 2, 1, 7, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 3, 31, 31, 21, 13, 2, 1, 8, 4, 3, 0, 0, false, false);
            int[] target = { 25, 4, 8, 7, 5, 23 };
            target[5] = -1;
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x566731ad94c53529ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(4, 2, 28, 21, 31, 31, 2, 1, 8, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 21, 31, 15, 31, 31, 3, 0, 18, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(24, 15, 8, 31, 16, 31, 2, 1, 19, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(17, 13, 31, 9, 2, 31, 2, 0, 13, 3, 3, 0, 0, false, false);
            int[] target = { 4, 2, 28, 21, 15, 30 };
            target[5] = -1;
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x99c70e15fd792f78ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(21, 10, 15, 31, 18, 31, 2, 1, 6, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 18, 31, 31, 29, 31, 3, 1, 20, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 29, 7, 31, 25, 11, 2, 0, 1, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 4, 28, 31, 31, 18, 2, 0, 14, 0, 3, 0, 0, false, false);
            int[] target = { 21, 10, 15, 18, 29, 9 };
            target[5] = -1;
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x7cae0d4906ac70aful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(25, 31, 26, 26, 25, 31, 2, 0, 2, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 31, 31, 25, 24, 31, 3, 0, 24, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 17, 31, 1, 16, 2, 1, 24, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 12, 2, 23, 9, 2, 0, 24, 1, 3, 0, 0, false, false);
            int[] target = { 25, 26, 26, 25, 24, 24 };
            target[5] = -1;
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x126865c9fb2b291eul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 24, 20, 12, 11, 2, 1, 0, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 12, 11, 31, 19, 3, 0, 9, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(14, 14, 26, 23, 31, 31, 2, 0, 0, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 27, 7, 5, 6, 2, 1, 17, 1, 3, 0, 0, false, false);
            int[] target = { 24, 20, 12, 11, 19, 30 };
            target[5] = -1;
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x55b8d1d473d5cd1aul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(9, 31, 10, 9, 15, 31, 2, 0, 10, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(9, 31, 31, 15, 28, 31, 3, 0, 24, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(10, 16, 19, 31, 31, 14, 2, 0, 20, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(8, 10, 31, 29, 31, 6, 2, 0, 12, 2, 3, 0, 0, false, false);
            int[] target = { 9, 10, 9, 15, 28, 18 };
            target[5] = -1;
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xe6fb839435958977ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(1, 31, 20, 15, 25, 31, 2, 1, 18, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 31, 25, 5, 31, 31, 3, 1, 7, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 31, 29, 31, 12, 6, 2, 1, 19, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 28, 18, 17, 31, 25, 2, 0, 12, 5, 3, 0, 0, false, false);
            int[] target = { 1, 20, 15, 25, 5, 3 };
            target[5] = -1;
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x261fc1f00a605211ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(25, 12, 31, 31, 14, 27, 2, 0, 2, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(12, 31, 31, 31, 14, 27, 3, 0, 2, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 0, 31, 26, 31, 29, 2, 1, 2, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(9, 15, 14, 8, 31, 31, 2, 1, 7, 5, 3, 0, 0, false, false);
            int[] target = { 25, 12, 14, 27, 14, 14 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xaf15b79e8cb6c6e1ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(2, 31, 5, 26, 19, 31, 2, 1, 16, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(5, 31, 31, 26, 19, 31, 3, 1, 16, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 17, 29, 31, 19, 4, 2, 1, 5, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(15, 25, 22, 31, 6, 31, 2, 1, 8, 3, 3, 0, 0, false, false);
            int[] target = { 2, 5, 26, 19, 15, 20 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x87e8145f67d83f11ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 17, 29, 31, 19, 4, 2, 1, 5, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 29, 31, 19, 4, 3, 1, 5, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 25, 22, 31, 6, 31, 2, 1, 8, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(18, 30, 31, 19, 29, 31, 2, 1, 6, 2, 3, 0, 0, false, false);
            int[] target = { 17, 29, 19, 4, 31, 10 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa8ac5d48a75a96cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(16, 31, 9, 2, 31, 1, 2, 1, 2, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 9, 2, 31, 1, 3, 1, 2, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 29, 31, 3, 31, 24, 2, 1, 17, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 9, 15, 0, 31, 31, 2, 0, 20, 3, 3, 0, 0, false, false);
            int[] target = { 16, 9, 2, 1, 21, 28 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xaccdc8c74c74100bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(17, 18, 31, 19, 31, 10, 2, 0, 19, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(18, 31, 31, 19, 31, 10, 3, 0, 19, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 3, 31, 31, 3, 11, 2, 0, 11, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(28, 3, 31, 31, 31, 10, 2, 0, 6, 2, 3, 0, 0, false, false);
            int[] target = { 17, 18, 19, 10, 8, 25 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd1b37d2f310fe105ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 18, 22, 27, 29, 31, 2, 0, 0, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 22, 31, 27, 29, 31, 3, 0, 0, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(22, 31, 0, 31, 19, 4, 2, 0, 24, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 31, 31, 25, 15, 27, 2, 0, 20, 2, 3, 0, 0, false, false);
            int[] target = { 18, 22, 27, 29, 16, 4 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfbde94815ae686b5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(20, 4, 4, 31, 22, 31, 2, 1, 13, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(4, 4, 22, 31, 31, 31, 3, 1, 13, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(26, 31, 24, 31, 6, 25, 2, 1, 24, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(27, 8, 31, 10, 6, 31, 2, 1, 22, 2, 3, 0, 0, false, false);
            int[] target = { 20, 4, 4, 22, 7, 31 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xccdc8c74c74100b0ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(4, 31, 15, 31, 10, 6, 2, 0, 3, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 31, 10, 31, 31, 6, 3, 0, 3, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(7, 8, 15, 31, 31, 29, 2, 1, 4, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 6, 31, 14, 7, 13, 2, 1, 22, 0, 3, 0, 0, false, false);
            int[] target = { 4, 15, 10, 6, 30, 26 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb9ef3bbafb7173bdul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(12, 7, 28, 31, 20, 31, 2, 1, 15, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(7, 28, 20, 31, 31, 31, 3, 1, 15, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 18, 31, 25, 1, 27, 2, 0, 24, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 17, 29, 26, 16, 2, 1, 21, 0, 3, 0, 0, false, false);
            int[] target = { 12, 7, 28, 20, 9, 24 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x726bc1c2727c889ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(12, 28, 17, 31, 12, 31, 2, 1, 15, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 17, 12, 31, 31, 31, 3, 1, 15, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(21, 31, 0, 20, 18, 31, 2, 0, 13, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 28, 31, 31, 12, 20, 2, 0, 10, 4, 3, 0, 0, false, false);
            int[] target = { 12, 28, 17, 12, 13, 16 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x71376ce6d12b5dd1ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(2, 27, 25, 31, 25, 31, 2, 0, 3, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(27, 25, 31, 31, 25, 31, 3, 0, 3, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 20, 20, 31, 31, 25, 2, 0, 23, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(30, 31, 16, 18, 8, 31, 2, 1, 20, 3, 3, 0, 0, false, false);
            int[] target = { 2, 27, 25, 25, 8, 19 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x8fa36988cf3b2f47ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(16, 31, 24, 23, 31, 1, 2, 1, 18, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 24, 23, 31, 1, 3, 1, 18, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 5, 31, 31, 24, 14, 2, 1, 7, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(12, 9, 31, 12, 31, 13, 2, 1, 3, 2, 3, 0, 0, false, false);
            int[] target = { 16, 24, 23, 1, 31, 15 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x232d6d142e937d3ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(2, 22, 26, 13, 31, 31, 2, 1, 0, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(22, 26, 31, 13, 31, 31, 3, 1, 0, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 3, 26, 31, 29, 18, 2, 0, 23, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 19, 26, 31, 20, 2, 0, 21, 5, 3, 0, 0, false, false);
            int[] target = { 2, 22, 26, 13, 21, 2 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4bde9dea85770341ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 3, 25, 22, 15, 31, 2, 1, 1, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 25, 22, 31, 15, 31, 3, 1, 1, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 18, 16, 2, 31, 7, 2, 1, 7, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 24, 25, 15, 30, 31, 2, 1, 4, 3, 3, 0, 0, false, false);
            int[] target = { 3, 25, 22, 15, 19, 2 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf8ed4fed77e072f7ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(19, 23, 31, 29, 31, 20, 2, 1, 0, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(23, 29, 31, 31, 31, 20, 3, 1, 0, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 11, 31, 20, 31, 31, 2, 1, 17, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 7, 7, 31, 30, 13, 2, 1, 18, 4, 3, 0, 0, false, false);
            int[] target = { 19, 23, 29, 20, 7, 21 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf6b745ff06a462a5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 2, 14, 17, 10, 2, 0, 8, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 14, 17, 10, 3, 0, 8, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 16, 31, 23, 31, 2, 0, 12, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(6, 22, 7, 7, 31, 31, 2, 1, 23, 5, 3, 0, 0, false, false);
            int[] target = { 2, 14, 17, 10, 6, 2 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa79e0c52875b538cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 27, 3, 21, 15, 2, 0, 3, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 3, 31, 21, 15, 3, 0, 3, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 3, 22, 18, 31, 2, 1, 20, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 27, 20, 10, 2, 31, 2, 1, 14, 3, 3, 0, 0, false, false);
            int[] target = { 27, 3, 21, 15, 14, 23 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd5ce98c6dc3161c2ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(9, 20, 27, 31, 26, 31, 2, 1, 5, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(20, 31, 27, 31, 26, 31, 3, 1, 5, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 31, 11, 31, 29, 2, 2, 0, 0, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(1, 31, 31, 30, 31, 22, 2, 1, 18, 5, 3, 0, 0, false, false);
            int[] target = { 9, 20, 27, 26, 17, 11 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xae5dc249ee1197b4ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 22, 8, 31, 24, 31, 2, 0, 13, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(22, 8, 24, 31, 31, 31, 3, 0, 13, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(5, 31, 31, 20, 16, 20, 2, 0, 14, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 10, 31, 27, 8, 29, 2, 1, 0, 0, 3, 0, 0, false, false);
            int[] target = { 28, 22, 8, 24, 14, 6 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x743820ae6417ed1ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(9, 2, 31, 26, 3, 31, 2, 0, 13, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(2, 31, 31, 26, 3, 31, 3, 0, 13, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(12, 31, 18, 25, 31, 27, 2, 1, 9, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(6, 31, 31, 13, 20, 23, 2, 0, 14, 2, 3, 0, 0, false, false);
            int[] target = { 9, 2, 26, 3, 24, 13 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfb6627a43c68b85ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(5, 31, 31, 26, 19, 31, 3, 1, 16, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 31, 31, 31, 20, 31, 4, 0, 23, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 17, 29, 31, 19, 4, 2, 1, 5, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(15, 25, 22, 31, 6, 31, 2, 1, 8, 3, 3, 0, 0, false, false);
            int[] target = { 5, 26, 19, 15, 20, 16 };
            target[5] = -1;
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x87e8145f67d83f11ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 8, 11, 31, 10, 31, 3, 1, 10, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 1, 31, 31, 6, 31, 4, 0, 8, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 1, 27, 8, 1, 31, 2, 0, 9, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(18, 15, 31, 31, 14, 30, 2, 0, 5, 2, 3, 0, 0, false, false);
            int[] target = { 8, 11, 10, 1, 6, 10 };
            target[5] = -1;
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x39fb4010f98723d2ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 28, 12, 31, 21, 3, 1, 19, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 14, 31, 31, 4, 1, 15, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(26, 29, 13, 31, 1, 31, 2, 1, 19, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(8, 25, 31, 31, 9, 27, 2, 1, 6, 2, 3, 0, 0, false, false);
            int[] target = { 28, 12, 21, 31, 14, 19 };
            target[5] = -1;
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x10f4202a6fd1d98dul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 31, 24, 26, 29, 3, 1, 8, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 11, 24, 31, 4, 0, 3, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 17, 31, 6, 31, 4, 2, 1, 3, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 28, 17, 31, 15, 29, 2, 1, 6, 4, 3, 0, 0, false, false);
            int[] target = { 24, 26, 29, 11, 24, 26 };
            target[5] = -1;
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa8ac5d48a75a96c0ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 31, 23, 1, 12, 3, 1, 14, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 25, 31, 30, 4, 0, 3, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(30, 31, 2, 3, 31, 29, 2, 1, 22, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(10, 31, 31, 28, 20, 29, 2, 1, 4, 1, 3, 0, 0, false, false);
            int[] target = { 23, 1, 12, 25, 30, 14 };
            target[5] = -1;
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x7a5fda77d86a77c5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(29, 31, 31, 13, 12, 31, 3, 0, 0, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(20, 31, 31, 8, 31, 31, 4, 0, 24, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(11, 17, 28, 31, 0, 31, 2, 0, 11, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(19, 24, 31, 14, 11, 31, 2, 0, 19, 2, 3, 0, 0, false, false);
            int[] target = { 29, 13, 12, 20, 8, 0 };
            target[5] = -1;
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xcfda0087cc391e90ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 31, 31, 24, 31, 3, 1, 0, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 17, 31, 31, 2, 31, 4, 0, 23, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 15, 6, 22, 29, 2, 1, 13, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 29, 22, 31, 31, 6, 2, 0, 22, 4, 3, 0, 0, false, false);
            int[] target = { 31, 31, 24, 17, 2, 0 };
            target[5] = -1;
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x624cdabbbe87070dul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 6, 31, 26, 20, 31, 3, 1, 14, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 19, 31, 2, 31, 31, 4, 0, 17, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 31, 17, 26, 12, 2, 0, 9, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 7, 17, 18, 13, 31, 2, 1, 17, 3, 3, 0, 0, false, false);
            int[] target = { 6, 26, 20, 19, 2, 14 };
            target[5] = -1;
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x192699b7b8d4fccul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(19, 15, 1, 31, 31, 31, 3, 1, 6, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(17, 31, 6, 31, 31, 31, 4, 1, 6, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(14, 21, 31, 5, 22, 31, 2, 1, 1, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 6, 31, 1, 31, 0, 2, 0, 5, 2, 3, 0, 0, false, false);
            int[] target = { 19, 15, 1, 17, 6, 31 };
            target[5] = -1;
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x75f75bed4a078bd1ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 22, 31, 16, 5, 3, 0, 16, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 2, 31, 4, 31, 4, 0, 14, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 31, 4, 30, 7, 2, 1, 5, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(27, 31, 5, 31, 9, 28, 2, 0, 22, 1, 3, 0, 0, false, false);
            int[] target = { 22, 16, 5, 2, 4, 16 };
            target[5] = -1;
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x1af0bfe727b49da7ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 15, 5, 31, 9, 31, 3, 0, 21, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 4, 31, 29, 31, 4, 1, 6, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 6, 22, 16, 15, 2, 1, 6, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 4, 31, 15, 7, 31, 2, 0, 22, 0, 3, 0, 0, false, false);
            int[] target = { 15, 5, 9, 4, 29, 21 };
            target[5] = -1;
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x967491caa04070d7ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 4, 16, 27, 31, 31, 3, 0, 15, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 20, 9, 31, 31, 31, 4, 1, 10, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 22, 6, 1, 31, 11, 2, 0, 5, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(7, 31, 0, 1, 31, 24, 2, 1, 8, 5, 3, 0, 0, false, false);
            int[] target = { 4, 16, 27, 20, 9, 15 };
            target[5] = -1;
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x591cc1eebc4c5c52ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 24, 30, 31, 12, 31, 3, 1, 13, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 11, 22, 31, 31, 31, 4, 0, 20, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 17, 31, 21, 22, 5, 2, 1, 13, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(1, 17, 18, 31, 31, 14, 2, 0, 19, 4, 3, 0, 0, false, false);
            int[] target = { 24, 30, 12, 11, 22, 26 };
            target[5] = -1;
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9a5d39bd46ceeb32ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(14, 31, 0, 31, 31, 31, 3, 1, 1, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 21, 14, 31, 31, 31, 4, 1, 10, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 27, 31, 16, 21, 31, 2, 0, 21, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 29, 0, 31, 9, 0, 2, 1, 6, 4, 3, 0, 0, false, false);
            int[] target = { 14, 31, 0, 21, 14, 1 };
            target[5] = -1;
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4106ad4a80bee21bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(26, 23, 31, 16, 31, 31, 3, 1, 11, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 27, 31, 22, 31, 31, 4, 1, 22, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(24, 31, 20, 12, 31, 1, 2, 1, 11, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(16, 4, 19, 11, 31, 31, 2, 1, 20, 3, 3, 0, 0, false, false);
            int[] target = { 26, 23, 16, 27, 22, 11 };
            target[5] = -1;
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x7165eac25f7f926ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 3, 4, 31, 31, 5, 3, 1, 22, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 23, 10, 31, 31, 31, 4, 0, 2, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 19, 6, 24, 31, 25, 2, 1, 3, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(9, 21, 17, 31, 6, 31, 2, 1, 23, 4, 3, 0, 0, false, false);
            int[] target = { 3, 4, 5, 23, 10, 22 };
            target[5] = -1;
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2fa92bb7bb416b69ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 31, 18, 10, 29, 3, 1, 3, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 9, 31, 4, 1, 9, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(26, 31, 18, 31, 25, 26, 2, 1, 24, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 23, 19, 20, 31, 26, 2, 1, 10, 5, 3, 0, 0, false, false);
            int[] target = { 18, 10, 29, 31, 9, 3 };
            target[5] = -1;
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa3e31d7917253e56ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 16, 31, 1, 31, 3, 0, 24, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 20, 31, 3, 31, 4, 0, 22, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 21, 25, 16, 12, 31, 2, 1, 19, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(12, 31, 31, 7, 1, 31, 2, 1, 6, 2, 3, 0, 0, false, false);
            int[] target = { 31, 16, 1, 20, 3, 24 };
            target[5] = -1;
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x71557b41abf4b51ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(4, 31, 7, 8, 31, 31, 3, 1, 14, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 21, 17, 31, 31, 4, 1, 0, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 23, 3, 5, 31, 6, 2, 1, 15, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(28, 31, 22, 24, 31, 17, 2, 1, 13, 5, 3, 0, 0, false, false);
            int[] target = { 4, 7, 8, 21, 17, 27 };
            target[5] = -1;
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x36a134a89debcd36ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 7, 31, 26, 31, 31, 3, 0, 1, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 30, 31, 4, 31, 31, 4, 1, 20, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 3, 31, 0, 16, 2, 1, 18, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(8, 25, 9, 31, 31, 24, 2, 0, 2, 4, 3, 0, 0, false, false);
            int[] target = { 7, 31, 26, 30, 4, 1 };
            target[5] = -1;
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xda23c70eca4fc8ddul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(13, 31, 6, 3, 31, 31, 3, 0, 7, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(12, 31, 14, 31, 31, 31, 4, 1, 2, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 23, 15, 31, 31, 18, 2, 1, 3, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 19, 31, 19, 11, 10, 2, 0, 16, 0, 3, 0, 0, false, false);
            int[] target = { 13, 6, 3, 12, 14, 7 };
            target[5] = -1;
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x77292062c05b67f3ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation22()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 31, 19, 31, 24, 31, 3, 0, 13, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 18, 31, 2, 31, 4, 1, 10, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 11, 11, 20, 11, 31, 2, 1, 6, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 30, 7, 31, 13, 23, 2, 1, 1, 4, 3, 0, 0, false, false);
            int[] target = { 7, 19, 24, 18, 2, 13 };
            target[5] = -1;
            var res = searcher.Calculate(22, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x51458478591bd7bdul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation23()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 18, 31, 4, 31, 21, 3, 1, 19, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 21, 31, 25, 31, 31, 4, 1, 2, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 17, 30, 22, 16, 31, 2, 1, 21, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(19, 0, 31, 26, 31, 15, 2, 1, 19, 5, 3, 0, 0, false, false);
            int[] target = { 18, 4, 21, 21, 25, 19 };
            target[5] = -1;
            var res = searcher.Calculate(23, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xaf6bfb0bb5537588ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(6, 31, 30, 31, 31, 21, 3, 1, 5, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(13, 31, 2, 31, 31, 31, 4, 1, 21, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(7, 13, 31, 31, 24, 25, 2, 1, 17, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(17, 31, 31, 14, 17, 26, 2, 1, 23, 1, 3, 0, 0, false, false);
            int[] target = { 6, 30, 21, 13, 2, 5 };
            target[5] = -1;
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x1477345b9e2edb26ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation25()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 31, 31, 31, 31, 13, 3, 0, 18, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 31, 25, 31, 31, 31, 4, 0, 2, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(5, 18, 25, 7, 31, 31, 2, 1, 18, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(27, 30, 31, 15, 13, 31, 2, 1, 4, 2, 3, 0, 0, false, false);
            int[] target = { 28, 31, 13, 28, 25, 28 };
            target[5] = -1;
            var res = searcher.Calculate(25, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xef4c64f320b74feful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(15, 31, 13, 31, 26, 31, 3, 1, 20, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(13, 31, 31, 31, 8, 31, 4, 0, 13, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(19, 5, 31, 16, 10, 31, 2, 1, 21, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(30, 1, 28, 9, 31, 31, 2, 1, 4, 3, 3, 0, 0, false, false);
            int[] target = { 15, 13, 26, 13, 8, 20 };
            target[5] = -1;
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9e5220202f99d923ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 3, 28, 31, 1, 31, 3, 1, 19, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 1, 3, 31, 31, 31, 4, 0, 19, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(16, 10, 31, 31, 17, 3, 2, 1, 9, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(0, 1, 17, 31, 31, 0, 2, 0, 14, 4, 3, 0, 0, false, false);
            int[] target = { 3, 28, 1, 3, 14, 19 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x15158ba914eb52d8ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 10, 31, 31, 17, 3, 3, 1, 9, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 3, 29, 4, 0, 9, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 1, 17, 31, 31, 0, 2, 0, 14, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(5, 31, 7, 9, 11, 31, 2, 0, 16, 3, 3, 0, 0, false, false);
            int[] target = { 10, 17, 3, 29, 16, 25 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x97b83d1e3788bd33ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 17, 31, 29, 29, 3, 1, 16, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 29, 31, 13, 31, 4, 0, 24, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(26, 31, 2, 31, 23, 9, 2, 0, 21, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(21, 6, 31, 20, 31, 9, 2, 0, 18, 2, 3, 0, 0, false, false);
            int[] target = { 17, 29, 29, 13, 6, 16 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x1fa0517d9f60fc44ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(22, 25, 31, 31, 31, 5, 3, 1, 6, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(5, 31, 31, 31, 31, 15, 4, 1, 6, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(15, 31, 9, 0, 5, 31, 2, 0, 6, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 25, 15, 22, 31, 31, 2, 0, 14, 3, 3, 0, 0, false, false);
            int[] target = { 22, 25, 5, 15, 21, 25 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3f40a2fb3ec1f888ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation0()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(10, 31, 31, 21, 31, 8, 3, 0, 4, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(8, 31, 31, 16, 31, 31, 4, 0, 24, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 19, 9, 5, 31, 2, 1, 8, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(8, 31, 17, 19, 31, 19, 2, 0, 10, 5, 3, 0, 0, false, false);
            int[] target = { 10, 21, 8, 16, 28, 4 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(0, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x696bba4d68989e38ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 22, 31, 27, 29, 31, 3, 0, 0, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 29, 31, 31, 16, 31, 4, 0, 0, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(22, 31, 0, 31, 19, 4, 2, 0, 24, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 31, 31, 25, 15, 27, 2, 0, 20, 2, 3, 0, 0, false, false);
            int[] target = { 22, 27, 29, 16, 4, 27 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfbde94815ae686b5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 26, 31, 29, 31, 5, 3, 1, 5, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 5, 31, 9, 31, 31, 4, 0, 22, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(9, 15, 14, 8, 31, 31, 2, 1, 7, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(5, 31, 31, 7, 30, 19, 2, 0, 14, 1, 3, 0, 0, false, false);
            int[] target = { 26, 29, 5, 9, 2, 5 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x31b86913af54313cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 12, 21, 31, 31, 29, 3, 1, 17, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 29, 13, 31, 31, 31, 4, 1, 9, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 20, 31, 31, 26, 1, 2, 1, 4, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 11, 31, 31, 23, 23, 2, 0, 8, 4, 3, 0, 0, false, false);
            int[] target = { 12, 21, 29, 13, 5, 17 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x92e14c63cdb9dcdeul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 0, 1, 30, 31, 31, 3, 1, 1, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 30, 19, 31, 31, 4, 1, 17, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(12, 31, 31, 1, 28, 16, 2, 1, 11, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 1, 31, 1, 7, 2, 1, 3, 4, 3, 0, 0, false, false);
            int[] target = { 0, 1, 30, 19, 23, 1 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb2f010114886cd83ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(30, 31, 12, 31, 10, 31, 3, 1, 6, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(10, 31, 9, 31, 31, 31, 4, 1, 22, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 31, 19, 16, 5, 2, 0, 22, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 5, 8, 13, 29, 31, 2, 1, 18, 0, 3, 0, 0, false, false);
            int[] target = { 30, 12, 10, 9, 3, 6 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4f382ade0094f862ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 19, 9, 31, 31, 7, 3, 0, 21, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 7, 31, 31, 4, 4, 1, 21, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 11, 15, 14, 0, 31, 2, 1, 17, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(6, 22, 12, 31, 31, 12, 2, 1, 20, 4, 3, 0, 0, false, false);
            int[] target = { 19, 9, 7, 4, 29, 28 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xc6f8a602ae437745ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 17, 12, 31, 31, 31, 3, 1, 15, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(12, 31, 13, 31, 31, 31, 4, 0, 18, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(21, 31, 0, 20, 18, 31, 2, 0, 13, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 28, 31, 31, 12, 20, 2, 0, 10, 4, 3, 0, 0, false, false);
            int[] target = { 28, 17, 12, 13, 16, 15 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x71376ce6d12b5dd1ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 0, 31, 13, 31, 26, 3, 0, 3, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 26, 31, 22, 31, 31, 4, 1, 0, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(22, 31, 29, 24, 31, 31, 2, 0, 20, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 14, 31, 23, 1, 8, 2, 0, 15, 2, 3, 0, 0, false, false);
            int[] target = { 0, 13, 26, 22, 17, 3 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb461beccc1b47e89ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 25, 31, 28, 31, 3, 0, 16, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 28, 31, 22, 31, 4, 0, 17, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(17, 10, 31, 6, 31, 28, 2, 1, 5, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 31, 31, 9, 22, 28, 2, 0, 22, 1, 3, 0, 0, false, false);
            int[] target = { 31, 25, 28, 22, 2, 16 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4836f1443738f67eul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(23, 5, 31, 31, 31, 25, 3, 1, 6, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(25, 25, 31, 31, 31, 31, 4, 1, 3, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(17, 2, 31, 31, 3, 31, 2, 0, 12, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 26, 22, 31, 13, 5, 2, 1, 2, 4, 3, 0, 0, false, false);
            int[] target = { 23, 5, 25, 25, 19, 6 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd53c0271e6f0dab8ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(26, 31, 31, 27, 31, 13, 3, 0, 15, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(13, 31, 31, 31, 31, 20, 4, 1, 17, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 11, 19, 0, 16, 2, 0, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 18, 29, 31, 31, 25, 2, 1, 7, 4, 3, 0, 0, false, false);
            int[] target = { 26, 27, 13, 20, 23, 15 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xca71d4cd6e2d4f6aul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 26, 31, 31, 5, 16, 3, 1, 21, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 16, 31, 31, 9, 31, 4, 0, 15, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 27, 31, 19, 3, 31, 2, 0, 13, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(27, 12, 31, 31, 9, 19, 2, 1, 4, 2, 3, 0, 0, false, false);
            int[] target = { 26, 5, 16, 9, 10, 21 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xc7e13f6dda9e9a35ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 31, 6, 29, 25, 3, 1, 4, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 25, 17, 31, 4, 0, 4, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(1, 14, 10, 31, 18, 31, 2, 1, 11, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(27, 31, 0, 5, 31, 18, 2, 1, 13, 5, 3, 0, 0, false, false);
            int[] target = { 6, 29, 25, 17, 22, 25 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3af4b15fd380e619ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 28, 26, 31, 31, 8, 3, 1, 2, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 8, 31, 31, 31, 9, 4, 1, 0, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 9, 31, 22, 29, 17, 2, 1, 14, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 23, 9, 14, 7, 31, 2, 0, 12, 3, 3, 0, 0, false, false);
            int[] target = { 28, 26, 8, 9, 5, 2 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9bdb17f7e1eea65aul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(30, 31, 31, 31, 28, 11, 3, 1, 8, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(11, 31, 31, 31, 31, 7, 4, 1, 8, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(11, 31, 31, 3, 31, 7, 2, 0, 16, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(19, 3, 31, 28, 31, 0, 2, 0, 18, 2, 3, 0, 0, false, false);
            int[] target = { 30, 28, 11, 7, 3, 30 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x61f4917777c91de5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(29, 31, 0, 4, 31, 31, 3, 1, 0, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 4, 11, 31, 31, 4, 1, 0, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 18, 31, 16, 22, 31, 2, 1, 14, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(21, 7, 15, 28, 31, 31, 2, 0, 10, 3, 3, 0, 0, false, false);
            int[] target = { 29, 0, 4, 11, 7, 0 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xab73f694029e8047ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation22()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 22, 25, 31, 31, 8, 3, 1, 0, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 8, 31, 31, 29, 4, 0, 0, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 23, 31, 20, 25, 24, 2, 0, 2, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 4, 3, 31, 16, 31, 2, 0, 9, 3, 3, 0, 0, false, false);
            int[] target = { 22, 25, 8, 29, 28, 26 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(22, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x91cf5e02615543d1ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(2, 31, 31, 28, 2, 31, 3, 1, 18, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(2, 31, 31, 27, 31, 31, 4, 1, 20, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 22, 23, 25, 6, 2, 0, 11, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 25, 28, 31, 19, 2, 0, 22, 5, 3, 0, 0, false, false);
            int[] target = { 2, 28, 2, 27, 21, 18 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x40dec1b8c005809dul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation23()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 15, 31, 3, 14, 31, 3, 1, 10, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 14, 31, 31, 31, 31, 4, 1, 10, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(21, 24, 31, 2, 24, 31, 2, 1, 16, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(23, 31, 15, 20, 11, 31, 2, 1, 7, 1, 3, 0, 0, false, false);
            int[] target = { 15, 3, 14, 31, 19, 27 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(23, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf576938b24a02517ul, res[0]);
        }
    }
}
