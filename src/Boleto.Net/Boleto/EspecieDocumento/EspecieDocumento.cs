using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    public class EspecieDocumento : AbstractEspecieDocumento, IEspecieDocumento
    {

        #region Variaveis

        private IEspecieDocumento _IEspecieDocumento;

        #endregion

        #region Construtores

        internal EspecieDocumento()
        {
        }

        public EspecieDocumento(int CodigoBanco)
        {
            try
            {
                InstanciaEspecieDocumento(CodigoBanco, "0");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao instanciar objeto.", ex);
            }
        }

        public EspecieDocumento(int CodigoBanco, string codigoEspecie)
        {
            try
            {
                InstanciaEspecieDocumento(CodigoBanco, codigoEspecie);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao instanciar objeto.", ex);
            }
        }

        #endregion

        #region Propriedades da interface

        public override IBanco Banco
        {
            get { return _IEspecieDocumento.Banco; }
            set { _IEspecieDocumento.Banco = value; }
        }

        public override string Codigo
        {
            get { return _IEspecieDocumento.Codigo; }
            set { _IEspecieDocumento.Codigo = value; }
        }

        public override string Sigla
        {
            get
            {

                if (_IEspecieDocumento == null)
                {
                    return string.Empty;
                }

                return _IEspecieDocumento.Sigla;
            }
            set { _IEspecieDocumento.Sigla = value; }
        }

        public override string Especie
        {
            get { return _IEspecieDocumento.Especie; }
            set { _IEspecieDocumento.Especie = value; }
        }

        #endregion

        # region M�todos Privados

        private void InstanciaEspecieDocumento(int codigoBanco, string codigoEspecie)
        {
            try
            {
                switch (codigoBanco)
                {
                    //341 - Ita�
                    case 341:
                        _IEspecieDocumento = new EspecieDocumento_Itau(codigoEspecie);
                        break;
                    //479 - BankBoston
                    case 479:
                        _IEspecieDocumento = new EspecieDocumento_BankBoston(codigoEspecie);
                        break;
                    //422 - Safra
                    case 1:
                        _IEspecieDocumento = new EspecieDocumento_BancoBrasil(codigoEspecie);
                        break;
                    //237 - Bradesco
                    case 237:
                        _IEspecieDocumento = new EspecieDocumento_Bradesco(codigoEspecie);
                        break;
                    case 356:
                        _IEspecieDocumento = new EspecieDocumento_Real(codigoEspecie);
                        break;
                    //033 - Santander
                    case 33:
                        _IEspecieDocumento = new EspecieDocumento_Santander(codigoEspecie);
                        break;
                    case 347:
                        _IEspecieDocumento = new EspecieDocumento_Sudameris(codigoEspecie);
                        break;
                    //104 - Caixa
                    case 104:
                        _IEspecieDocumento = new EspecieDocumento_Caixa(codigoEspecie);
                        break;
                    //399 - HSBC
                    case 399:
                        _IEspecieDocumento = new EspecieDocumento_HSBC(codigoEspecie);
                        break;
                    //748 - Sicredi
                    case 748:
                        _IEspecieDocumento = new EspecieDocumento_Sicredi(codigoEspecie);
                        break;
                    //41 - Banrisul - sidneiklein
                    case 41:
                        _IEspecieDocumento = new EspecieDocumento_Banrisul(codigoEspecie);
                        break;
                    //085 - Cecred
                    case 85:
                        _IEspecieDocumento = new EspecieDocumento_Cecred(codigoEspecie);
                        break;
                    //756 - Sicoob
                    case 756:
                        _IEspecieDocumento = new EspecieDocumento_Sicoob(codigoEspecie);
                        break;
                    //004 Banco do Nordeste
                    case 4:
                        _IEspecieDocumento = new EspecieDocumento_Nordeste(codigoEspecie);
                        break;
					case 707:
						this._IEspecieDocumento = new EspecieDocumento_Daycoval(codigoEspecie);
		                break;
					case 637:
						this._IEspecieDocumento = new EspecieDocumento_Sofisa(codigoEspecie);
						break;
					default:
                        throw new Exception("C�digo do banco n�o implementando: " + codigoBanco);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a execu��o da transa��o.", ex);
            }
        }

        public static EspeciesDocumento CarregaTodas(int codigoBanco)
        {
            try
            {
                switch (codigoBanco)
                {
                    case 1:
                        return EspecieDocumento_BancoBrasil.CarregaTodas();
                    case 33:
                        return EspecieDocumento_Santander.CarregaTodas();
                    case 41:
                        return EspecieDocumento_Banrisul.CarregaTodas();
                    case 104:
                        return EspecieDocumento_Caixa.CarregaTodas();
                    case 237:
                        return EspecieDocumento_Bradesco.CarregaTodas();
                    case 341:
                        return EspecieDocumento_Itau.CarregaTodas();
                    case 347:
                        return EspecieDocumento_Sudameris.CarregaTodas();
                    case 356:
                        return EspecieDocumento_Real.CarregaTodas();
                    case 399:
                        return EspecieDocumento_HSBC.CarregaTodas();
                    case 479:
                        return EspecieDocumento_BankBoston.CarregaTodas();
                    case 748:
                        return EspecieDocumento_Sicredi.CarregaTodas();
                    case 756:
                        return EspecieDocumento_Sicoob.CarregaTodas();
                    case 85:
                        return EspecieDocumento_Cecred.CarregaTodas();
                    case 5:
                        return EspecieDocumento_Nordeste.CarregaTodas();
                    default:
                        throw new Exception("Esp�cies do Documento n�o implementado para o banco : " + codigoBanco);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar objetos", ex);
            }
        }

        # endregion

        public static string ValidaSigla(IEspecieDocumento especie)
        {
            try
            {
                return especie.Sigla;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string ValidaCodigo(IEspecieDocumento especie)
        {
            try
            {
                return especie.Codigo;
            }
            catch
            {
                return "0";
            }
        }
    }
}
