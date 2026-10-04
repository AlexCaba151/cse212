public class FeatureCollection
{
    // The GeoJSON response contains a collection of earthquake features.
    public Feature[] Features { get; set; } = [];
}

public class Feature
{
    // Each feature contains the earthquake properties.
    public EarthquakeProperties Properties { get; set; } = new();
}

public class EarthquakeProperties
{
    // The location where the earthquake occurred.
    public string Place { get; set; } = "";

    // The magnitude of the earthquake.
    public double Mag { get; set; }
}