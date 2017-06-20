using System;
using System.Collections.Generic;
using System.Linq;

namespace Interesting
{
    public interface ITriangle
    {
        int SideA { get; }
        int SideB { get; }
        int SideC { get; }
        bool IsValid();
    }

    public enum TriangleType
    {
        Scalene,
        Isoceles,
        Equilateral,
        Error
    }


    public interface ITriangleCriteria
    {
        TriangleType TriangleType { get; }
        bool IsValid(Triangle triangle);
    }

    public class Triangle
    {
        public Triangle(int sideA, int sideB, int sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public int SideA { get; }
        public int SideB { get; }
        public int SideC { get; }

        public virtual bool IsValid()
        {
            var allPositive = SideA > 0 && SideB > 0 && SideC > 0;
            if (!allPositive)
            {
                return false;
            }

            var isAccordingToTriangleTheory = (SideA + SideB > SideC) &&
                                              (SideA + SideC > SideB) &&
                                              (SideB + SideC > SideA);

            return isAccordingToTriangleTheory;


        }
    }

    public class ScaleneTriangle : ITriangleCriteria
    {
        public TriangleType TriangleType
        {
            get { return TriangleType.Scalene; }
        }

        bool ITriangleCriteria.IsValid(Triangle triangle)
        {
            return triangle != null &&
                   triangle.IsValid() &&
                   (triangle.SideA != triangle.SideB && triangle.SideA != triangle.SideC && triangle.SideB != triangle.SideC);
        }
    }

    public class IsoscelesTriangle : ITriangleCriteria
    {
        public TriangleType TriangleType
        {
            get { return TriangleType.Isoceles; }
        }

        bool ITriangleCriteria.IsValid(Triangle triangle)
        {
            return triangle != null &&
                   triangle.IsValid() &&
                   (triangle.SideA == triangle.SideB || triangle.SideA == triangle.SideC || triangle.SideB == triangle.SideC);
        }
    }

    public class EquilateralTriangle : ITriangleCriteria
    {
        public TriangleType TriangleType
        {
            get { return TriangleType.Equilateral; }
        }

        bool ITriangleCriteria.IsValid(Triangle triangle)
        {
            return triangle != null &&
                   triangle.IsValid() &&
                   (triangle.SideA == triangle.SideB && triangle.SideB == triangle.SideC);
        }
    }


    public class TriangleEvaluator
    {
        private readonly IEnumerable<ITriangleCriteria> _triangleCriterias;

        public TriangleEvaluator(IEnumerable<ITriangleCriteria> triangleCriterias )
        {
            if (triangleCriterias == null)
            {
                throw new NullReferenceException("No triangle criterias defined");
            }

            _triangleCriterias = triangleCriterias;
        }

        public virtual TriangleType GetTriangleType(int sideA, int sideB, int sideC)
        {
            var triangle = new Triangle(sideA, sideB, sideC);

            var triangleCriteria = _triangleCriterias.FirstOrDefault(criteria => criteria.IsValid(triangle));

            return triangleCriteria == null ? TriangleType.Error : triangleCriteria.TriangleType;
        }

    }
}