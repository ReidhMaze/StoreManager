using CustomComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreObjects;

namespace StoreManager.CustomComponentsLinker
{
    public class ProductsAndOrdersLinker
    {

        private OrdersPanel ordersPanel;
        private ProductsPanel productsPanel;
        private Dictionary<int, ProductDisplayPanel> productsPanelButtons;
        private Dictionary<int,  ProductDisplayPanel> productsPanelId;

        public ProductsAndOrdersLinker(OrdersPanel ordersPanel, ProductsPanel productsPanel)
        {

            this.ordersPanel = ordersPanel;
            this.productsPanel = productsPanel;
            this.productsPanelButtons = new Dictionary<int, ProductDisplayPanel>();
            this.productsPanelId = new Dictionary<int, ProductDisplayPanel>();

            foreach (ProductDisplayPanel pdpDisplay in this.productsPanel.PdpDisplays)
            {
                this.productsPanelButtons.Add(pdpDisplay.BtnAddToCart.GetHashCode(), pdpDisplay);

                if (pdpDisplay.Item != null) this.productsPanelId.Add(pdpDisplay.Item.Id, pdpDisplay);
            }
        }

        public ProductDisplayPanel GetProdDisplayPanel(int hashCode)
        {
            ProductDisplayPanel pdpOut = this.productsPanelButtons[hashCode];
            return pdpOut;
        }

        public Dictionary<int, ProductDisplayPanel> ProductsPanelId
        {
            get { return productsPanelId; }
        }

    }

}
