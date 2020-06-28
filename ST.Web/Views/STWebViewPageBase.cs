using Abp.Web.Mvc.Views;

namespace ST.Web.Views
{
    public abstract class STWebViewPageBase : STWebViewPageBase<dynamic>
    {

    }

    public abstract class STWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected STWebViewPageBase()
        {
            LocalizationSourceName = STConsts.LocalizationSourceName;
        }
    }
}