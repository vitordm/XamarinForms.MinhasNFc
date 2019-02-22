using MinhasNFc.Models;
using MinhasNFc.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasNFc.ViewModels
{
    public class NFcViewModel : BaseViewModel
    {
        private readonly NFcService _nfcService;
        public NFc Nfc { get; set; }
        public string Consumidor { get; set; }
        public string Comercio { get; set; }
        public string EnderecoComercio { get; set; }


        public NFcViewModel(NFc nfc)
        {
            _nfcService = new NFcService();
            Nfc = _nfcService.GetById(nfc.Id);

            if (Nfc.ConsumidorIdentificado)
            {
                Consumidor = $"CONSUMIDOR {Nfc.DocumentoConsumidor}";
            }
            else
            {
                Consumidor = "CONSUMIDOR NÃO IDENTIFICADO";
            }

            Comercio = $"{Nfc.Comercio.CNPJ} - {Nfc.Comercio.RazaoSocial}";
            EnderecoComercio = Nfc.Comercio.Endereco;
        }
    }
}
