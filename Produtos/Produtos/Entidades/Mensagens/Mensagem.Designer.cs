﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Produtos.Entidades.Mensagens {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Mensagem {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Mensagem() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Produtos.Entidades.Mensagens.Mensagem", typeof(Mensagem).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Não é permitida duplicidade de &quot;{0}&quot;.
        /// </summary>
        public static string EntidadeDuplicada {
            get {
                return ResourceManager.GetString("EntidadeDuplicada", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Não é permitida duplicidade de &quot;{0}&quot; para o informado no campo &quot;{1}&quot;..
        /// </summary>
        public static string EntidadeDuplicadaPorEntidade {
            get {
                return ResourceManager.GetString("EntidadeDuplicadaPorEntidade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O registro informado não foi encontrado..
        /// </summary>
        public static string EntidadeNaoEncontrada {
            get {
                return ResourceManager.GetString("EntidadeNaoEncontrada", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O campo &quot;{0}&quot; é obrigatório.
        /// </summary>
        public static string ParametroObrigatorio {
            get {
                return ResourceManager.GetString("ParametroObrigatorio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O campo &quot;{0}&quot; deve ser único.
        /// </summary>
        public static string ParametroUnico {
            get {
                return ResourceManager.GetString("ParametroUnico", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O registro &quot;{0}&quot; não foi encontrado.
        /// </summary>
        public static string RegistroNaoEncontrado {
            get {
                return ResourceManager.GetString("RegistroNaoEncontrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Usuário ou senha inválidos.
        /// </summary>
        public static string UsuarioOuSenhaInvalido {
            get {
                return ResourceManager.GetString("UsuarioOuSenhaInvalido", resourceCulture);
            }
        }
    }
}
