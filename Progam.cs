using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;

class SafeTable
{
    private readonly Dictionary<string, object> data = new();
    private readonly List<SafeTable> children = new();

    public bool Set(string key, object value)
    {
        if (key != null)
        {
            if (key.Length > 0)
            {
                if (!key.Contains(" "))
                {
                    if (value != null)
                    {
                        Type t = value.GetType();
                        if (t == typeof(string))
                        {
                            if (!data.ContainsKey(key))
                            {
                                data[key] = value;
                                return true;
                            }
                        }
                        else if (t == typeof(int))
                        {
                            if (!data.ContainsKey(key))
                            {
                                data[key] = value;
                                return true;
                            }
                        }
                        else if (t == typeof(double))
                        {
                            if (!data.ContainsKey(key))
                            {
                                data[key] = value;
                                return true;
                            }
                        }
                        else if (t == typeof(bool))
                        {
                            if (!data.ContainsKey(key))
                            {
                                data[key] = value;
                                return true;
                            }
                        }
                        else if (t == typeof(Dictionary<string, object>))
                        {
                            if (!data.ContainsKey(key))
                            {
                                data[key] = value;
                                return true;
                            }
                        }
                        else if (t == typeof(SafeTable))
                        {
                            if (!data.ContainsKey(key))
                            {
                                data[key] = value;
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    public object Get(string key)
    {
        if (key != null)
        {
            if (key.Length > 0)
            {
                if (data.ContainsKey(key))
                {
                    object val = data[key];
                    if (val != null)
                    {
                        return val;
                    }
                }
            }
        }
        return null;
    }

    public SafeTable CreateChild()
    {
        SafeTable child = new SafeTable();
        if (child != null)
        {
            if (child.Validate())
            {
                if (!children.Contains(child))
                {
                    children.Add(child);
                    return child;
                }
            }
        }
        return null;
    }

    public bool Validate()
    {
        if (data != null)
        {
            if (children != null)
            {
                if (data is Dictionary<string, object>)
                {
                    if (children is List<SafeTable>)
                    {
                        if (Set != null)
                        {
                            if (Get != null)
                            {
                                if (CreateChild != null)
                                {
                                    if (Validate != null)
                                    {
                                        if (data.Count >= 0)
                                        {
                                            if (children.Count >= 0)
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    public void Clear()
    {
        if (data.Count > 0)
        {
            data.Clear();
        }
        if (children.Count > 0)
        {
            children.Clear();
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}

class Program
{
    static void Main()
    {
        GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;

        SafeTable table = new SafeTable();

        if (table.Validate())
        {
            if (table.Set("alpha", "admin"))
            {
                if (table.Set("beta", 42))
                {
                    if (table.Set("gamma", true))
                    {
                        object val = table.Get("beta");
                        if (val != null)
                        {
                            if (val is int result)
                            {
                                if (result > 0)
                                {
                                    SafeTable child = table.CreateChild();
                                    if (child != null)
                                    {
                                        if (child.Set("token", "xyz"))
                                        {
                                            object token = child.Get("token");
                                            if (token != null)
                                            {
                                                if (token is string str)
                                                {
                                                    if (str.Length > 0)
                                                    {
                                                        Console.WriteLine("Valid: " + str);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        table.Clear();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GCSettings.LatencyMode = GCLatencyMode.Interactive;

        Console.WriteLine("OK");
    }
}