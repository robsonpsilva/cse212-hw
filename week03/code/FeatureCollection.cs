using System.Dynamic;


public class FeatureCollection
{
    public string Type { get; set; }
    public Metadata Metadata { get; set; }
    public List<Feature> Features { get; set; }
    public List<double> Bbox { get; set; }
}

public class Metadata
{
    public long Generated { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string Api { get; set; }
    public int Count { get; set; }
}

public class Feature
{
    public string Type { get; set; }
    public Properties Properties { get; set; }
    public Geometry Geometry { get; set; }
    public string Id { get; set; }
}

public class Properties
{
    public double Mag { get; set; }
    public string Place { get; set; }
   
}

public class Geometry
{
    public string Type { get; set; }
    public List<double> Coordinates { get; set; }
}