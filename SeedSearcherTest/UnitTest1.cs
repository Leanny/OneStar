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
        public void Test_Fixed2_6_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 0, 1, 27, 10, 2, 0, 1, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 10, 31, 16, 9, 3, 1, 3, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(13, 14, 31, 31, 31, 9, 2, 0, 20, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(22, 16, 31, 9, 31, 26, 2, 1, 1, 5, 3, 0, 0, false, false);
            int[] target = { 0, 1, 27, 10, 16, 9 };
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xee0f478de22f4cc0ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation2()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(28, 31, 20, 10, 31, 24, 2, 1, 9, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(24, 31, 31, 25, 31, 28, 3, 1, 18, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(19, 31, 14, 30, 31, 31, 2, 1, 19, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(20, 7, 31, 31, 1, 2, 2, 0, 1, 2, 3, 0, 0, false, false);
            int[] target = { 28, 20, 10, 24, 25, 28 };
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf4bfb4efb0d4ef8aul, res[0]);
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
        public void Test_Fixed2_6_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 4, 7, 18, 31, 31, 2, 1, 16, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(1, 15, 31, 16, 31, 31, 3, 1, 14, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 13, 8, 31, 11, 10, 2, 1, 10, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 1, 27, 8, 1, 31, 2, 0, 9, 0, 3, 0, 0, false, false);
            int[] target = { 20, 4, 7, 18, 1, 15 };
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb7588e9bd6e9b977ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 29, 5, 30, 31, 31, 2, 1, 6, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 6, 31, 26, 20, 31, 3, 1, 14, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 31, 17, 26, 12, 2, 0, 9, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 7, 17, 18, 13, 31, 2, 1, 17, 3, 3, 0, 0, false, false);
            int[] target = { 29, 5, 30, 31, 31, 24 };
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x192699b7b8d4fccul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(5, 27, 28, 31, 12, 31, 2, 1, 0, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(12, 19, 12, 31, 31, 31, 3, 0, 24, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(19, 15, 24, 31, 27, 31, 2, 1, 11, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 28, 26, 18, 1, 2, 1, 7, 0, 3, 0, 0, false, false);
            int[] target = { 5, 27, 28, 12, 19, 12 };
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xa4a897c1e2f6b2bcul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(9, 31, 31, 9, 28, 31, 2, 0, 24, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 0, 31, 19, 3, 1, 15, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 20, 17, 28, 16, 2, 1, 14, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 23, 0, 24, 14, 2, 1, 15, 0, 3, 0, 0, false, false);
            int[] target = { 9, 9, 28, 31, 0, 19 };
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x689a10857ad51fb0ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(29, 13, 10, 12, 31, 31, 2, 0, 0, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(12, 30, 31, 27, 31, 31, 3, 1, 20, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(13, 31, 31, 7, 7, 11, 2, 0, 24, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(7, 31, 5, 31, 22, 26, 2, 1, 19, 1, 3, 0, 0, false, false);
            int[] target = { 29, 13, 10, 12, 30, 27 };
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x461245b0bc360a0cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 3, 31, 31, 31, 10, 2, 0, 6, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 14, 31, 31, 31, 6, 3, 0, 21, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 31, 24, 8, 31, 25, 2, 0, 9, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(25, 31, 5, 31, 2, 17, 2, 0, 2, 4, 3, 0, 0, false, false);
            int[] target = { 28, 3, 31, 10, 28, 14 };
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd6f8e019764ab5bbul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(5, 31, 9, 23, 7, 31, 2, 1, 23, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(4, 31, 21, 31, 25, 31, 3, 1, 8, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(21, 28, 13, 31, 29, 31, 2, 1, 22, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(7, 13, 31, 7, 6, 31, 2, 1, 23, 3, 3, 0, 0, false, false);
            int[] target = { 5, 9, 23, 7, 13, 7 };
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x42deecc7c34bccf4ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(10, 18, 31, 14, 31, 23, 2, 0, 15, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 11, 31, 15, 31, 4, 3, 0, 13, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(6, 25, 31, 10, 31, 19, 2, 0, 9, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 31, 31, 2, 4, 15, 2, 1, 21, 1, 3, 0, 0, false, false);
            int[] target = { 10, 18, 14, 23, 24, 11 };
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x6279c51ae2d8aff5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 8, 11, 31, 31, 4, 2, 0, 3, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 18, 10, 31, 31, 28, 3, 1, 6, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 6, 31, 31, 30, 24, 2, 0, 13, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(2, 9, 31, 23, 31, 25, 2, 1, 6, 5, 3, 0, 0, false, false);
            int[] target = { 8, 11, 31, 4, 18, 10 };
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x28c8f13f89a2ae78ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(20, 18, 31, 31, 31, 21, 2, 0, 9, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(0, 3, 31, 30, 31, 31, 3, 1, 22, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 31, 12, 19, 30, 31, 2, 0, 22, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(0, 31, 9, 26, 31, 15, 2, 1, 18, 5, 3, 0, 0, false, false);
            int[] target = { 20, 18, 31, 21, 0, 3 };
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2528b9b9af8206d0ul, res[0]);
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
        public void Test_Fixed2_6_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(29, 13, 16, 1, 31, 31, 2, 1, 10, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 1, 11, 17, 31, 31, 3, 0, 24, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 0, 4, 20, 31, 16, 2, 1, 13, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(30, 28, 31, 27, 31, 7, 2, 0, 18, 5, 3, 0, 0, false, false);
            int[] target = { 29, 13, 16, 1, 11, 17 };
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xacdd8f55056272bcul, res[0]);
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
            searcher.RegisterPokemon1(31, 24, 27, 31, 21, 20, 2, 0, 13, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 20, 16, 31, 10, 31, 3, 1, 17, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 1, 22, 21, 31, 16, 2, 0, 23, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(4, 31, 15, 21, 31, 31, 2, 1, 18, 1, 3, 0, 0, false, false);
            int[] target = { 24, 27, 21, 20, 16, 10 };
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9be4f965a395f4edul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(19, 31, 11, 31, 28, 8, 2, 0, 23, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(8, 31, 22, 31, 31, 17, 3, 1, 18, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 10, 4, 5, 14, 2, 1, 19, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 2, 4, 27, 30, 31, 2, 0, 8, 0, 3, 0, 0, false, false);
            int[] target = { 19, 11, 28, 8, 22, 17 };
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9680cce070b567eul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_6_Deviation25()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 24, 31, 26, 9, 31, 2, 0, 13, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 12, 10, 3, 1, 22, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(16, 10, 31, 6, 31, 22, 2, 0, 19, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(10, 31, 20, 31, 19, 11, 2, 0, 13, 1, 3, 0, 0, false, false);
            int[] target = { 24, 26, 9, 31, 12, 10 };
            var res = searcher.Calculate(25, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x25c4c65202b56fc8ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(18, 30, 31, 19, 29, 31, 2, 1, 6, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(29, 29, 31, 31, 10, 31, 3, 0, 5, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 6, 3, 0, 31, 12, 2, 0, 2, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 22, 30, 31, 30, 6, 2, 0, 3, 0, 3, 0, 0, false, false);
            int[] target = { 18, 30, 19, 29, 29, 10 };
            target[5] = -1;
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfd028becfb07e22ul, res[0]);
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
        public void Test_Fixed2_5_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 1, 26, 21, 6, 2, 0, 24, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 21, 6, 30, 3, 1, 2, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(11, 5, 31, 31, 23, 6, 2, 0, 20, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(19, 3, 31, 31, 31, 27, 2, 1, 0, 4, 3, 0, 0, false, false);
            int[] target = { 1, 26, 21, 6, 30, 23 };
            target[5] = -1;
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3a69b240d4f31833ul, res[0]);
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
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(2, 28, 31, 18, 15, 31, 2, 1, 13, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(18, 15, 31, 5, 31, 31, 3, 1, 22, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(19, 24, 31, 9, 31, 0, 2, 1, 20, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 7, 27, 26, 31, 17, 2, 0, 3, 5, 3, 0, 0, false, false);
            int[] target = { 2, 28, 18, 15, 5, 21 };
            target[5] = -1;
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x8f2e5315040c57f4ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(20, 26, 8, 29, 31, 31, 2, 0, 22, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(8, 29, 31, 12, 31, 31, 3, 1, 22, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 13, 31, 14, 9, 29, 2, 0, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(13, 16, 24, 31, 2, 31, 2, 0, 17, 3, 3, 0, 0, false, false);
            int[] target = { 20, 26, 8, 29, 12, 25 };
            target[5] = -1;
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x1fef0fc583a5ffb4ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(1, 31, 7, 5, 31, 17, 2, 0, 1, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(17, 31, 30, 2, 31, 31, 3, 1, 1, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 27, 5, 31, 31, 14, 2, 0, 1, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(3, 31, 3, 31, 9, 18, 2, 0, 24, 4, 3, 0, 0, false, false);
            int[] target = { 1, 7, 5, 17, 30, 2 };
            target[5] = -1;
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x83a24c943feb3faul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(17, 31, 31, 11, 16, 31, 2, 1, 10, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(16, 31, 19, 31, 16, 31, 3, 1, 16, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 31, 31, 25, 23, 18, 2, 0, 23, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 13, 10, 12, 6, 2, 1, 20, 1, 3, 0, 0, false, false);
            int[] target = { 17, 31, 11, 16, 19, 16 };
            target[5] = -1;
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x93a6281788666576ul, res[0]);
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
        public void Test_Fixed2_5_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(2, 27, 31, 24, 31, 4, 2, 0, 24, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(24, 4, 31, 31, 31, 16, 3, 0, 13, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 31, 20, 22, 31, 8, 2, 0, 19, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(13, 31, 6, 31, 30, 23, 2, 1, 8, 4, 3, 0, 0, false, false);
            int[] target = { 2, 27, 24, 4, 16, 12 };
            target[5] = -1;
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3ebf14c58834df5ful, res[0]);
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
        public void Test_Fixed2_5_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 24, 15, 15, 31, 12, 2, 0, 22, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 9, 3, 4, 31, 31, 3, 0, 11, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(4, 31, 7, 7, 1, 31, 2, 1, 24, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 20, 12, 31, 14, 24, 2, 0, 10, 4, 3, 0, 0, false, false);
            int[] target = { 24, 15, 15, 12, 20, 24 };
            target[5] = -1;
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x1a0a569824932885ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 28, 30, 24, 31, 11, 2, 1, 2, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 21, 14, 31, 31, 2, 3, 1, 23, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 31, 0, 31, 14, 30, 2, 0, 19, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 30, 13, 31, 27, 25, 2, 0, 4, 4, 3, 0, 0, false, false);
            int[] target = { 28, 30, 24, 11, 21, 14 };
            target[5] = -1;
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf727197a69104a7cul, res[0]);
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
        public void Test_Fixed2_5_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(19, 7, 14, 31, 24, 31, 2, 1, 16, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 1, 10, 31, 16, 31, 3, 0, 4, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 1, 20, 17, 7, 2, 0, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 26, 22, 31, 8, 31, 2, 1, 17, 0, 3, 0, 0, false, false);
            int[] target = { 19, 7, 14, 24, 1, 10 };
            target[5] = -1;
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x5beea9ce91e22047ul, res[0]);
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
        public void Test_Fixed2_5_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 0, 20, 31, 17, 6, 2, 1, 1, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 17, 6, 31, 31, 11, 3, 0, 0, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(14, 31, 25, 31, 4, 3, 2, 1, 12, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 3, 31, 13, 26, 31, 2, 1, 5, 2, 3, 0, 0, false, false);
            int[] target = { 0, 20, 17, 6, 11, 30 };
            target[5] = -1;
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3580e92b737e6b1cul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 17, 15, 16, 31, 2, 0, 16, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 16, 11, 31, 17, 3, 1, 1, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 11, 30, 31, 20, 3, 2, 1, 6, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(4, 2, 10, 31, 31, 26, 2, 1, 11, 4, 3, 0, 0, false, false);
            int[] target = { 17, 15, 16, 31, 6, 12 };
            target[5] = -1;
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xba7db1a8bb8398aeul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation22()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(9, 31, 18, 15, 17, 31, 2, 0, 18, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 31, 31, 17, 8, 31, 3, 0, 16, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(8, 31, 6, 17, 16, 31, 2, 0, 5, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(22, 6, 3, 31, 18, 31, 2, 0, 11, 3, 3, 0, 0, false, false);
            int[] target = { 9, 18, 15, 17, 8, 24 };
            target[5] = -1;
            var res = searcher.Calculate(22, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x900b73eb23892d10ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation23()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 20, 5, 1, 31, 29, 2, 1, 17, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 1, 29, 7, 31, 31, 3, 0, 11, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 14, 22, 31, 21, 8, 2, 1, 1, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 9, 9, 2, 31, 2, 1, 0, 0, 3, 0, 0, false, false);
            int[] target = { 20, 5, 1, 29, 7, 30 };
            target[5] = -1;
            var res = searcher.Calculate(23, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x62dc05e6dfe40c4bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_5_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 24, 14, 10, 23, 31, 2, 0, 19, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 23, 31, 0, 25, 31, 3, 1, 8, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(9, 31, 31, 22, 26, 28, 2, 1, 10, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 27, 23, 13, 24, 2, 0, 2, 0, 3, 0, 0, false, false);
            int[] target = { 24, 14, 10, 23, 0, 25 };
            target[5] = -1;
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4778a2721faab5adul, res[0]);
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
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(23, 31, 22, 31, 4, 14, 2, 1, 7, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(14, 31, 19, 31, 31, 22, 3, 1, 20, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 5, 26, 19, 31, 2, 1, 16, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 17, 29, 31, 19, 4, 2, 1, 5, 0, 3, 0, 0, false, false);
            int[] target = { 23, 22, 4, 14, 19, 22 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(2, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x54562ea453ad4b6ul, res[0]);
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
        public void Test_Fixed2_4_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(30, 11, 10, 31, 31, 29, 2, 1, 1, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(29, 17, 31, 31, 31, 11, 3, 1, 1, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 17, 25, 6, 21, 2, 0, 17, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(10, 31, 31, 27, 13, 30, 2, 1, 19, 1, 3, 0, 0, false, false);
            int[] target = { 30, 11, 10, 29, 17, 11 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x5ee0f478de22f4ccul, res[0]);
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
        public void Test_Fixed2_4_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(7, 3, 31, 31, 5, 31, 2, 1, 17, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 24, 31, 3, 1, 0, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 15, 6, 22, 29, 2, 1, 13, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(29, 29, 22, 31, 31, 6, 2, 0, 22, 4, 3, 0, 0, false, false);
            int[] target = { 7, 3, 5, 31, 31, 24 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x624cdabbbe87070dul, res[0]);
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
            searcher.RegisterPokemon1(30, 4, 11, 31, 31, 19, 2, 0, 14, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(14, 31, 0, 31, 31, 31, 3, 1, 1, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 27, 31, 16, 21, 31, 2, 0, 21, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 29, 0, 31, 9, 0, 2, 1, 6, 4, 3, 0, 0, false, false);
            int[] target = { 30, 4, 11, 19, 12, 13 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4106ad4a80bee21bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation11()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 27, 31, 25, 31, 2, 0, 2, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 25, 31, 28, 31, 3, 0, 16, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(17, 10, 31, 6, 31, 28, 2, 1, 5, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 31, 31, 9, 22, 28, 2, 0, 22, 1, 3, 0, 0, false, false);
            int[] target = { 31, 27, 31, 25, 28, 22 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(11, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4836f1443738f67eul, res[0]);
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
        public void Test_Fixed2_4_Deviation14()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(15, 31, 31, 6, 15, 2, 2, 1, 10, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(19, 31, 31, 31, 14, 19, 3, 0, 1, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(13, 31, 31, 23, 4, 20, 2, 0, 23, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(10, 31, 17, 19, 21, 31, 2, 1, 11, 1, 3, 0, 0, false, false);
            int[] target = { 15, 6, 15, 2, 23, 7 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(14, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2b10bbf5652f4974ul, res[0]);
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
        public void Test_Fixed2_4_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 14, 31, 9, 29, 26, 2, 0, 17, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 29, 26, 28, 3, 1, 17, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(26, 6, 1, 8, 31, 31, 2, 0, 8, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(0, 31, 31, 31, 3, 9, 2, 1, 14, 4, 3, 0, 0, false, false);
            int[] target = { 14, 9, 29, 26, 28, 13 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xebf9639c58171f0ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 31, 14, 13, 7, 2, 1, 10, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 7, 27, 3, 31, 3, 0, 10, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 12, 17, 31, 19, 2, 0, 17, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 14, 31, 30, 30, 30, 2, 0, 15, 2, 3, 0, 0, false, false);
            int[] target = { 31, 14, 13, 7, 27, 3 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x26de85077fa1dbeeul, res[0]);
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
        public void Test_Fixed2_4_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(25, 10, 31, 27, 24, 31, 2, 0, 18, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(10, 31, 31, 27, 24, 31, 3, 0, 18, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(16, 31, 19, 28, 22, 31, 2, 1, 23, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(1, 31, 31, 18, 18, 2, 2, 0, 22, 1, 3, 0, 0, false, false);
            int[] target = { 25, 10, 27, 24, 30, 3 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xdca13ba8f1fef023ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 28, 13, 31, 27, 17, 2, 1, 19, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 13, 27, 31, 31, 17, 3, 1, 19, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 0, 31, 29, 2, 25, 2, 0, 14, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(11, 31, 27, 31, 15, 27, 2, 0, 17, 1, 3, 0, 0, false, false);
            int[] target = { 28, 13, 27, 17, 13, 7 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x32ab7d1ba5157c03ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation22()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 12, 31, 30, 21, 2, 2, 1, 19, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 30, 31, 21, 31, 2, 3, 1, 19, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(18, 31, 10, 12, 31, 22, 2, 1, 3, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(13, 13, 28, 31, 31, 12, 2, 1, 20, 4, 3, 0, 0, false, false);
            int[] target = { 12, 30, 21, 2, 9, 17 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(22, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x5c10ffcb9decd7b3ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation23()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 4, 1, 12, 31, 2, 1, 24, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 1, 12, 31, 31, 3, 1, 24, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 5, 21, 19, 3, 2, 0, 14, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(15, 7, 4, 31, 31, 25, 2, 0, 4, 4, 3, 0, 0, false, false);
            int[] target = { 4, 1, 12, 31, 15, 31 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(23, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x5ad266e8523be424ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 4, 19, 9, 14, 2, 0, 23, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 19, 9, 31, 14, 3, 0, 23, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(11, 28, 31, 5, 31, 11, 2, 0, 14, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 11, 31, 20, 23, 18, 2, 1, 7, 2, 3, 0, 0, false, false);
            int[] target = { 4, 19, 9, 14, 6, 27 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x67de866ca3b4057aul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation25()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(27, 31, 31, 6, 18, 4, 2, 0, 4, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(6, 31, 31, 31, 18, 4, 3, 0, 4, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 7, 31, 31, 3, 26, 2, 0, 2, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 13, 31, 13, 22, 27, 2, 1, 22, 0, 3, 0, 0, false, false);
            int[] target = { 27, 6, 18, 4, 4, 20 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(25, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf3af363f0f3c21e5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation26()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 31, 1, 8, 17, 31, 2, 1, 14, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(1, 31, 8, 17, 31, 31, 3, 1, 14, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 2, 31, 0, 3, 22, 2, 0, 18, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 18, 31, 31, 0, 11, 2, 0, 16, 4, 3, 0, 0, false, false);
            int[] target = { 28, 1, 8, 17, 21, 6 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(26, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfa680705fef93ef7ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed2_4_Deviation27()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 24, 31, 31, 3, 28, 2, 0, 6, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(24, 3, 31, 31, 31, 28, 3, 0, 6, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(9, 11, 3, 31, 31, 16, 2, 1, 13, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(30, 31, 22, 31, 25, 4, 2, 0, 5, 4, 3, 0, 0, false, false);
            int[] target = { 28, 24, 3, 28, 26, 4 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(27, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xdc60d42a163cb98ful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation1()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 0, 12, 31, 31, 22, 3, 1, 7, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 2, 31, 31, 7, 4, 1, 10, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 22, 30, 31, 30, 6, 2, 0, 3, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(16, 10, 31, 31, 17, 3, 2, 1, 9, 2, 3, 0, 0, false, false);
            int[] target = { 0, 12, 22, 9, 2, 7 };
            target[5] = -1;
            var res = searcher.Calculate(1, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9272da33f24de87dul, res[0]);
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
        public void Test_Fixed3_5_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 31, 25, 25, 12, 3, 0, 24, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 20, 31, 13, 4, 0, 22, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 27, 3, 1, 31, 31, 2, 0, 2, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(22, 31, 8, 26, 28, 31, 2, 1, 23, 1, 3, 0, 0, false, false);
            int[] target = { 25, 25, 12, 20, 13, 26 };
            target[5] = -1;
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x66dcb86a3f0c74b9ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation6()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 31, 31, 28, 31, 7, 3, 0, 22, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 12, 31, 22, 4, 1, 19, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 10, 16, 2, 31, 19, 2, 0, 18, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 12, 25, 22, 16, 2, 0, 11, 0, 3, 0, 0, false, false);
            int[] target = { 20, 28, 7, 0, 12, 22 };
            target[5] = -1;
            var res = searcher.Calculate(6, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2fdeec6c4a7d6ec7ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation7()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(29, 31, 17, 11, 31, 31, 3, 1, 21, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(11, 31, 25, 31, 31, 31, 4, 1, 18, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(14, 31, 11, 20, 31, 2, 2, 1, 2, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(3, 31, 30, 21, 26, 31, 2, 0, 23, 1, 3, 0, 0, false, false);
            int[] target = { 29, 17, 11, 11, 25, 21 };
            target[5] = -1;
            var res = searcher.Calculate(7, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xc32eaafff3a34006ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation8()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 8, 12, 31, 22, 3, 0, 7, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 24, 31, 31, 21, 4, 0, 5, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(10, 31, 14, 31, 20, 22, 2, 0, 4, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(21, 17, 31, 31, 28, 10, 2, 0, 12, 2, 3, 0, 0, false, false);
            int[] target = { 8, 12, 22, 0, 15, 7 };
            target[5] = -1;
            var res = searcher.Calculate(8, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xda4512745f87d70bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation9()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(12, 31, 4, 31, 31, 31, 3, 1, 13, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(13, 31, 28, 31, 31, 31, 4, 1, 20, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 21, 3, 31, 29, 30, 2, 0, 11, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(26, 31, 31, 15, 7, 18, 2, 0, 0, 1, 3, 0, 0, false, false);
            int[] target = { 12, 4, 31, 23, 27, 13 };
            target[5] = -1;
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x4fd48e650b8b438ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation10()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(25, 31, 31, 31, 2, 30, 3, 0, 9, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 31, 31, 31, 20, 31, 4, 0, 3, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 28, 28, 10, 20, 31, 2, 0, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(20, 12, 28, 31, 31, 30, 2, 0, 8, 4, 3, 0, 0, false, false);
            int[] target = { 25, 2, 30, 2, 18, 9 };
            target[5] = -1;
            var res = searcher.Calculate(10, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xefd866c545d63fd2ul, res[0]);
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
        public void Test_Fixed3_5_Deviation12()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(2, 26, 31, 31, 31, 15, 3, 1, 8, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(10, 31, 31, 31, 31, 8, 4, 0, 2, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(23, 31, 31, 31, 28, 28, 2, 0, 17, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(14, 31, 19, 1, 31, 28, 2, 1, 10, 5, 3, 0, 0, false, false);
            int[] target = { 2, 26, 15, 9, 10, 8 };
            target[5] = -1;
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd193c94739e8f014ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(12, 31, 9, 31, 31, 15, 3, 1, 7, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(7, 31, 2, 31, 31, 31, 4, 0, 4, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 25, 31, 25, 9, 14, 2, 0, 12, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 13, 31, 27, 15, 31, 2, 0, 23, 2, 3, 0, 0, false, false);
            int[] target = { 12, 9, 15, 17, 13, 7 };
            target[5] = -1;
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x229bc5b00c343aeul, res[0]);
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
        public void Test_Fixed3_5_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(20, 4, 26, 31, 31, 31, 3, 0, 16, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(30, 4, 31, 31, 31, 31, 4, 0, 10, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(6, 31, 5, 18, 31, 1, 2, 1, 18, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(25, 27, 31, 1, 31, 13, 2, 1, 20, 2, 3, 0, 0, false, false);
            int[] target = { 20, 4, 26, 30, 4, 16 };
            target[5] = -1;
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x640db022160d7d8aul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 2, 31, 31, 11, 7, 3, 0, 13, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 3, 31, 31, 27, 31, 4, 0, 24, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(28, 31, 31, 30, 18, 18, 2, 0, 1, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 19, 24, 10, 25, 2, 1, 16, 1, 3, 0, 0, false, false);
            int[] target = { 2, 11, 7, 22, 22, 13 };
            target[5] = -1;
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x59cbf938d8f79484ul, res[0]);
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
        public void Test_Fixed3_5_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(26, 31, 31, 31, 27, 7, 3, 0, 7, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 31, 31, 31, 28, 31, 4, 1, 24, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(25, 26, 15, 31, 7, 31, 2, 0, 1, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(7, 31, 14, 20, 5, 31, 2, 0, 21, 1, 3, 0, 0, false, false);
            int[] target = { 26, 27, 7, 30, 10, 29 };
            target[5] = -1;
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb5841ab98fb62b3ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation19()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(10, 31, 31, 31, 18, 23, 3, 1, 20, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(29, 31, 31, 31, 31, 9, 4, 0, 12, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 23, 20, 30, 31, 31, 2, 0, 3, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 31, 27, 22, 2, 2, 0, 5, 0, 3, 0, 0, false, false);
            int[] target = { 10, 18, 23, 17, 7, 20 };
            target[5] = -1;
            var res = searcher.Calculate(19, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xb7f4659e831626b4ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(25, 31, 21, 31, 18, 31, 3, 1, 23, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(25, 31, 31, 31, 0, 31, 4, 0, 3, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(21, 19, 9, 31, 4, 31, 2, 0, 22, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(25, 21, 7, 22, 31, 31, 2, 1, 20, 3, 3, 0, 0, false, false);
            int[] target = { 25, 21, 18, 25, 0, 30 };
            target[5] = -1;
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x90c8faab0ff46bf6ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(29, 29, 31, 31, 28, 31, 3, 1, 9, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(19, 24, 31, 31, 31, 31, 4, 1, 12, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(26, 20, 31, 21, 31, 0, 2, 0, 21, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 16, 10, 29, 8, 2, 1, 10, 0, 3, 0, 0, false, false);
            int[] target = { 29, 29, 28, 19, 24, 9 };
            target[5] = -1;
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x84bbf64d07b8adabul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation22()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 2, 31, 31, 8, 31, 3, 1, 24, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 28, 31, 31, 24, 31, 4, 1, 1, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(6, 24, 14, 31, 0, 31, 2, 1, 10, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(18, 26, 23, 31, 31, 7, 2, 0, 22, 4, 3, 0, 0, false, false);
            int[] target = { 2, 8, 31, 5, 28, 24 };
            target[5] = -1;
            var res = searcher.Calculate(22, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd77ff9fb3005ec9bul, res[0]);
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
        public void Test_Fixed3_5_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(4, 31, 13, 24, 31, 31, 3, 0, 12, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 12, 31, 31, 31, 4, 0, 1, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 24, 22, 1, 31, 30, 2, 1, 17, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(13, 11, 18, 31, 31, 10, 2, 1, 7, 4, 3, 0, 0, false, false);
            int[] target = { 4, 13, 24, 12, 31, 12 };
            target[5] = -1;
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xee3b723cf866ea1ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation25()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(26, 10, 31, 31, 28, 31, 3, 1, 6, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(15, 14, 31, 31, 31, 31, 4, 0, 18, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(8, 30, 31, 4, 8, 31, 2, 1, 4, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 20, 31, 26, 17, 5, 2, 0, 13, 2, 3, 0, 0, false, false);
            int[] target = { 26, 10, 28, 15, 14, 6 };
            target[5] = -1;
            var res = searcher.Calculate(25, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xdbcbc748162ae6faul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation26()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 24, 31, 3, 22, 3, 1, 14, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 19, 31, 27, 31, 4, 1, 8, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 10, 31, 19, 23, 31, 2, 0, 21, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 13, 4, 23, 23, 2, 1, 4, 1, 3, 0, 0, false, false);
            int[] target = { 24, 3, 22, 21, 19, 27 };
            target[5] = -1;
            var res = searcher.Calculate(26, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3e461aa0c0b16824ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation27()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 8, 31, 11, 4, 3, 1, 7, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 9, 31, 31, 11, 4, 1, 7, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 29, 31, 9, 5, 12, 2, 1, 20, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(18, 22, 31, 10, 31, 3, 2, 0, 8, 5, 3, 0, 0, false, false);
            int[] target = { 8, 11, 4, 9, 11, 29 };
            target[5] = -1;
            var res = searcher.Calculate(27, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x219b1915a15f50aeul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_5_Deviation28()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(20, 19, 31, 31, 31, 7, 3, 0, 24, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 11, 31, 31, 31, 27, 4, 0, 12, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(0, 24, 31, 23, 31, 2, 2, 1, 3, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(28, 31, 31, 22, 16, 29, 2, 0, 7, 1, 3, 0, 0, false, false);
            int[] target = { 20, 19, 7, 22, 11, 24 };
            target[5] = -1;
            var res = searcher.Calculate(28, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x8a5ef66c115398e6ul, res[0]);
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
        public void Test_Fixed3_4_Deviation3()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 11, 31, 31, 6, 19, 3, 0, 0, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 4, 8, 4, 1, 1, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(23, 31, 22, 31, 4, 14, 2, 1, 7, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(2, 31, 5, 26, 19, 31, 2, 1, 16, 1, 3, 0, 0, false, false);
            int[] target = { 11, 6, 19, 18, 23, 0 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(3, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x82a2b175229d6a5bul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation4()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 31, 9, 30, 22, 3, 0, 23, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 29, 31, 23, 4, 0, 24, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 3, 11, 22, 18, 2, 0, 0, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(26, 31, 6, 30, 6, 31, 2, 1, 14, 1, 3, 0, 0, false, false);
            int[] target = { 9, 30, 22, 28, 29, 23 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(4, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xe2a79d59a0e1ba92ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation5()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(18, 31, 31, 19, 31, 10, 3, 0, 19, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(10, 31, 31, 31, 31, 8, 4, 1, 9, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 3, 31, 31, 3, 11, 2, 0, 11, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(28, 3, 31, 31, 31, 10, 2, 0, 6, 2, 3, 0, 0, false, false);
            int[] target = { 18, 19, 10, 8, 25, 19 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(5, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd1b37d2f310fe105ul, res[0]);
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
            searcher.RegisterPokemon1(31, 8, 31, 28, 27, 31, 3, 1, 22, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 27, 31, 3, 31, 31, 4, 1, 22, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(14, 29, 31, 31, 3, 15, 2, 1, 4, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 9, 21, 31, 23, 27, 2, 1, 2, 4, 3, 0, 0, false, false);
            int[] target = { 8, 28, 27, 3, 3, 25 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(9, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x38296ea58fabf224ul, res[0]);
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
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 14, 31, 31, 31, 6, 3, 0, 21, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 8, 31, 31, 31, 31, 4, 1, 18, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(20, 31, 24, 8, 31, 25, 2, 0, 9, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(25, 31, 5, 31, 2, 17, 2, 0, 2, 4, 3, 0, 0, false, false);
            int[] target = { 28, 14, 6, 12, 31, 21 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(12, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xd6f8e019764ab5bbul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation13()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(4, 31, 31, 31, 31, 20, 3, 0, 15, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(26, 31, 31, 31, 31, 15, 4, 1, 17, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 23, 4, 31, 8, 15, 2, 1, 6, 4, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(6, 30, 31, 31, 29, 31, 2, 0, 24, 2, 3, 0, 0, false, false);
            int[] target = { 4, 31, 20, 26, 26, 15 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(13, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x9895217dee60a5f5ul, res[0]);
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
        public void Test_Fixed3_4_Deviation15()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(26, 22, 31, 31, 3, 31, 3, 1, 22, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(19, 31, 31, 31, 7, 31, 4, 0, 4, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(7, 31, 31, 22, 26, 0, 2, 0, 20, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(30, 8, 31, 6, 31, 11, 2, 1, 11, 2, 3, 0, 0, false, false);
            int[] target = { 26, 22, 3, 23, 10, 22 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(15, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xfddee3c85315ed01ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation16()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(5, 31, 23, 14, 31, 31, 3, 1, 8, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 5, 14, 31, 31, 4, 1, 14, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(30, 28, 31, 5, 31, 19, 2, 1, 23, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 11, 31, 31, 25, 19, 2, 1, 1, 2, 3, 0, 0, false, false);
            int[] target = { 5, 23, 14, 7, 17, 30 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(16, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2f7209b7a5057495ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation17()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 19, 31, 31, 0, 31, 3, 1, 13, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 13, 31, 18, 31, 4, 1, 21, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(9, 31, 28, 15, 31, 23, 2, 1, 15, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(22, 31, 31, 29, 14, 24, 2, 1, 4, 1, 3, 0, 0, false, false);
            int[] target = { 19, 31, 0, 5, 1, 13 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(17, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x57f3d9dbc71233feul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation18()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(4, 31, 7, 22, 31, 31, 3, 0, 8, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(1, 31, 31, 8, 31, 31, 4, 1, 4, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 13, 4, 24, 3, 2, 1, 18, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(20, 19, 7, 31, 7, 31, 2, 0, 15, 3, 3, 0, 0, false, false);
            int[] target = { 4, 7, 22, 26, 1, 8 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(18, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x51b4ef90c173fd8dul, res[0]);
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
        public void Test_Fixed3_4_Deviation20()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 25, 31, 4, 8, 3, 1, 24, 0, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 8, 31, 31, 9, 4, 1, 2, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(19, 31, 19, 18, 23, 31, 2, 1, 5, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 27, 10, 17, 9, 31, 2, 0, 20, 3, 3, 0, 0, false, false);
            int[] target = { 25, 4, 8, 9, 1, 24 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(20, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x458555752567ca2ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation21()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(19, 31, 31, 31, 14, 19, 3, 0, 1, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(23, 31, 31, 31, 31, 1, 4, 0, 3, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(13, 31, 31, 23, 4, 20, 2, 0, 23, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(10, 31, 17, 19, 21, 31, 2, 1, 11, 1, 3, 0, 0, false, false);
            int[] target = { 19, 14, 19, 28, 23, 1 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(21, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x2b10bbf5652f4974ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation22()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 31, 31, 1, 6, 25, 3, 0, 0, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 0, 31, 2, 4, 0, 12, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(30, 29, 31, 9, 30, 31, 2, 0, 3, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(24, 23, 31, 28, 14, 31, 2, 1, 22, 2, 3, 0, 0, false, false);
            int[] target = { 1, 6, 25, 16, 28, 0 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(22, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf109beed1e3ac681ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation23()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(2, 31, 31, 23, 22, 31, 3, 0, 1, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(20, 31, 31, 1, 31, 31, 4, 0, 21, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(27, 29, 31, 31, 3, 0, 2, 0, 23, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(26, 31, 23, 13, 31, 19, 2, 1, 21, 5, 3, 0, 0, false, false);
            int[] target = { 2, 23, 22, 20, 20, 1 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(23, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xad2a84c568ff5943ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation24()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(20, 3, 31, 29, 31, 31, 3, 0, 13, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(29, 12, 31, 31, 31, 31, 4, 0, 13, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 27, 8, 31, 27, 31, 2, 0, 23, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(19, 10, 31, 10, 8, 31, 2, 0, 20, 2, 3, 0, 0, false, false);
            int[] target = { 20, 3, 29, 12, 28, 25 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(24, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xccc5953ff18b2fc1ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation25()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 31, 31, 31, 31, 13, 3, 0, 18, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(28, 31, 25, 31, 31, 31, 4, 0, 2, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(5, 18, 25, 7, 31, 31, 2, 1, 18, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(27, 30, 31, 15, 13, 31, 2, 1, 4, 2, 3, 0, 0, false, false);
            int[] target = { 28, 31, 13, 28, 25, 28 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(25, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xef4c64f320b74feful, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation26()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(28, 8, 17, 31, 31, 31, 3, 0, 10, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 17, 6, 31, 31, 31, 4, 0, 5, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(2, 31, 31, 8, 28, 18, 2, 1, 12, 1, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(8, 31, 15, 0, 31, 2, 2, 1, 19, 5, 3, 0, 0, false, false);
            int[] target = { 28, 8, 17, 6, 4, 10 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(26, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x3f190da0480259a5ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation27()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(5, 28, 31, 31, 29, 31, 3, 1, 5, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(29, 27, 31, 31, 31, 31, 4, 0, 17, 5, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 26, 25, 31, 29, 31, 2, 0, 3, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 0, 29, 27, 31, 22, 2, 1, 5, 5, 3, 0, 0, false, false);
            int[] target = { 5, 28, 29, 27, 10, 5 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(27, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xbca68227136979feul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation28()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 31, 17, 31, 2, 19, 3, 1, 10, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 31, 19, 11, 4, 0, 23, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(17, 31, 31, 14, 15, 12, 2, 1, 23, 2, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 31, 26, 4, 0, 2, 0, 2, 0, 3, 0, 0, false, false);
            int[] target = { 17, 2, 19, 11, 30, 10 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(28, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x55bd708008847c78ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation29()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(31, 0, 7, 22, 31, 31, 3, 0, 23, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 31, 23, 31, 31, 4, 0, 2, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(8, 31, 21, 2, 31, 30, 2, 1, 3, 5, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 26, 12, 31, 21, 31, 2, 0, 20, 4, 3, 0, 0, false, false);
            int[] target = { 0, 7, 22, 26, 31, 23 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(29, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xeddca2ac05b91395ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation30()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(0);
            searcher.RegisterPokemon1(4, 31, 5, 31, 31, 25, 3, 1, 15, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(25, 31, 23, 31, 31, 31, 4, 1, 15, 3, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(1, 4, 31, 10, 1, 31, 2, 0, 4, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(31, 31, 20, 9, 29, 15, 2, 1, 8, 0, 3, 0, 0, false, false);
            int[] target = { 4, 5, 25, 23, 23, 15 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(30, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0xf3fe60a18aab4d35ul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation31()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(19, 4, 31, 31, 29, 31, 3, 1, 1, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(29, 17, 31, 31, 31, 31, 4, 0, 10, 2, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(10, 31, 7, 14, 0, 31, 2, 1, 3, 3, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(15, 31, 9, 30, 31, 22, 2, 1, 6, 5, 3, 0, 0, false, false);
            int[] target = { 19, 4, 29, 17, 18, 1 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(31, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x40e31cdcf4f4dbbcul, res[0]);
        }
        [TestMethod]
        public void Test_Fixed3_4_Deviation32()
        {
            SeedSearcher searcher = new SeedSearcher(SeedSearcher.Mode.Star35);
            searcher.RegisterLSB(1);
            searcher.RegisterPokemon1(31, 27, 9, 31, 31, 2, 3, 0, 13, 4, 1, 0, 0, false, false);
            searcher.RegisterPokemon2(31, 31, 2, 31, 31, 20, 4, 0, 3, 1, 1, 0, 0, false, false);
            searcher.RegisterPokemon3(31, 31, 9, 10, 4, 13, 2, 1, 18, 0, 2, 0, 0, false, false);
            searcher.RegisterPokemon4(30, 31, 12, 31, 7, 17, 2, 0, 10, 4, 3, 0, 0, false, false);
            int[] target = { 27, 9, 2, 20, 28, 13 };
            target[5] = -1;
            target[4] = -1;
            var res = searcher.Calculate(32, target);
            Assert.IsTrue(res.Count > 0, "No seed found");
            Assert.AreEqual(0x456021ae0ba7134cul, res[0]);
        }
    }
}
