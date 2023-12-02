using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Tests
    {
        public class Part2test
        {
            [Fact]
            public void SumWithoutNegRows()
            {
            var secondPart = new Part2(10);
            var actualSum = secondPart.sum_in_pos_rows();

            var expectedSum = Enumerable.Range(0, secondPart.Matrix.GetLength(0))
            .Select(row =>
            Enumerable.Range(0, secondPart.Matrix.GetLength(1))
                .All(col => secondPart.Matrix[row, col] >= 0) ? 
                Enumerable.Range(0, secondPart.Matrix.GetLength(1))
                    .Sum(col => secondPart.Matrix[row, col]) : 0
            )
            .Sum();

            Assert.Equal(expectedSum, actualSum);
            }

            [Fact]
            public void MinSumInDiagonals()
            {
            var secondPart = new Part2(10);
            var actualSum = secondPart.min_sum();

            var bottomdiagonalSums = Enumerable.Range(0, secondPart.Size)
            .Select(i => Enumerable.Range(0, secondPart.Size)
                .TakeWhile(j => i + j < secondPart.Size)
                .Sum(j => secondPart.Matrix[i + j, j]))
            .ToList().Min();

            var topdiagonalSums = Enumerable.Range(1, secondPart.Size)
            .Select(j => Enumerable.Range(0, secondPart.Size)
                .TakeWhile(i => i + j < secondPart.Size)
                .Sum(i => secondPart.Matrix[i, j + i]))
            .ToList().Min();

            var expectedSum = 0;

            if (topdiagonalSums >= bottomdiagonalSums) expectedSum = bottomdiagonalSums;
            else expectedSum = topdiagonalSums;

            Assert.Equal(expectedSum, actualSum);
            }
        }
    }
