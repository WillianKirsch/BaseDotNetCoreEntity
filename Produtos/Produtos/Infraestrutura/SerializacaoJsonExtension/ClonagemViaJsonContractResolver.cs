using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Produtos.Infraestrutura.SerializacaoJsonExtension
{
    public class ClonagemViaJsonContractResolver : DefaultContractResolver
    {
        private readonly Func<bool> _funcaoDeValidacaoDeProfundidade;
        private readonly Func<string, bool> _funcaoDeValidacaoDePropriedade;

        public ClonagemViaJsonContractResolver(Func<bool> funcaoDeValidacao, Func<string, bool> funcaoDeValidacaoDePropriedade)
        {
            _funcaoDeValidacaoDeProfundidade = funcaoDeValidacao;
            _funcaoDeValidacaoDePropriedade = funcaoDeValidacaoDePropriedade;
        }

        protected override JsonProperty CreateProperty(
            MemberInfo member, MemberSerialization memberSerialization)
        {
            var propriedade = base.CreateProperty(member, memberSerialization);
            var deveSerializarPropriedade = propriedade.ShouldSerialize;

            propriedade.ShouldSerialize = obj => _funcaoDeValidacaoDeProfundidade()
                                                && _funcaoDeValidacaoDePropriedade(propriedade.PropertyName)
                                                &&
                                               (deveSerializarPropriedade == null ||
                                               deveSerializarPropriedade(obj));
            return propriedade;
        }
    }
}
