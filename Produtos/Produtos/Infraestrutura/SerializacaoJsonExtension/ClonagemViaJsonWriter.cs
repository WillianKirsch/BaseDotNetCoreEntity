using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Infraestrutura.SerializacaoJsonExtension
{
    public class ClonagemViaJsonWriter : JsonTextWriter
    {
        public ClonagemViaJsonWriter(TextWriter textWriter) : base(textWriter) { }

        public int Profundidade { get; private set; }

        public override void WriteStartObject()
        {
            Profundidade++;
            base.WriteStartObject();
        }

        public override void WriteEndObject()
        {
            Profundidade--;
            base.WriteEndObject();
        }
    }
}
