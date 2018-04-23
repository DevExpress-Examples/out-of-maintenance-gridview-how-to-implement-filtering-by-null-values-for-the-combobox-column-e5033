Imports Microsoft.VisualBasic
Imports MVCxGridViewDataBinding.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace Q556797.Controllers
	Public Class HomeController
		Inherits Controller
		'
		' GET: /Home/

		Public Function Index() As ActionResult
			Return View()
		End Function
		Public Function GridPartial() As ActionResult
			Dim model = MyModel.GetModelList()
			Return PartialView(model)
		End Function
	End Class
End Namespace
