using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vnsf.Service.Data;

namespace Vnsf.Service.Contract
{
    public interface IAssetManagement
    {
        IQueryable<AssetData> GetAll();
        IQueryable<AssetData> GetByGroup(string assetGroup);
        void CreateAsset(AssetData asset);
    }
}
