# ajaxpro
基于ajaxpro 9.2.17.1 版本

在 Application_Start 中增加
HandlerConfiguration.DefaultSettings = () =>
{
	var setting = new AjaxProDefaultSettings();
	setting.PreHandlerExecute += (self, arg) =>
	{
		TKF.Common.showinfo.ShowInfo("\r\n\t{0} 方法 开始:\r\n\t参数: {1}", arg.MethodName, arg.Args);
	};

	setting.PostHandlerExecute += (self, arg) =>
	{
		TKF.Common.showinfo.ShowInfo("\r\n\t{0} 方法 结束:\r\n\t返回值: {1}", arg.MethodName, arg.Args);
	};
	return setting;
};