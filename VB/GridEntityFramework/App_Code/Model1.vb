Imports System.Data.Entity

Namespace GridEntityFramework

    Public Partial Class Model1
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=Model1")
        End Sub

        Public Overridable Property Categories As DbSet(Of Category)

        Public Overridable Property Products As DbSet(Of Product)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Entity(Of Product)().Property(Function(e) e.UnitPrice).HasPrecision(19, 4)
        End Sub
    End Class
End Namespace
