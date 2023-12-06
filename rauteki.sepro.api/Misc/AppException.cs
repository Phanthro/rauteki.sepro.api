
using System.Collections;
using System.Text;

namespace Rauteki.Sepro.Api.Misc;

public class AppException : Exception
{    
    public AppException()
    {
        
    }

    public AppException(string? message) : base(message)
    {
        
    }

    public override string ToString()
    {

        StringBuilder m = new();
        m.AppendLine(base.Message);
        if (base.Data.Count > 0) {
            m.AppendLine("  Extra details:");
            foreach (DictionaryEntry de in base.Data)
                m.AppendLine($"   subject: {de.Key.ToString()}      message: {de.Value}");
        }

        return m.ToString();
    }
    
}