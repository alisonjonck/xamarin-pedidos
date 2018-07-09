using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Pedidos_Domain.Interfaces;
using Pedidos_Service.Services;
using UIKit;
using System.Linq;

namespace Pedidos_App.iOS
{
    public partial class ViewController : UIViewController
    {
        readonly IProdutoService produtoService;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

            produtoService = new ProdutoService();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            BtnMessage.TouchUpInside += async (object sender, EventArgs e) =>
            {
                var list = await produtoService.GetProdutosAsync();

                BtnMessage.SetTitle($"{list.Count()} Produtos cadastrados!", UIControlState.Normal);
                BtnMessage.Enabled = false;
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
