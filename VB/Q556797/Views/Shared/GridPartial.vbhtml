@CODE
DevExpress.Data.Filtering.EnumProcessingHelper.RegisterEnum(GetType(MVCxGridViewDataBinding.Models.MyModel.ModelStateEnum))
END CODE

@Html.DevExpress().GridView(Sub(settings) 
	settings.Name = "grid"
	settings.KeyFieldName = "ModelID"
	settings.Settings.ShowFilterRow = True
	settings.CommandColumn.ShowClearFilterButton= True
	settings.CommandColumn.Visible = True
	settings.CommandColumn.ShowEditButton = True
	settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridPartial"}
	settings.Columns.Add("ModelID")
	settings.Columns.Add("ModelName")
	settings.Columns.Add(Sub(col)
           col.FieldName = "ModelState"
		   col.Settings.AutoFilterCondition = AutoFilterCondition.Equals
		   col.ColumnType = MVCxGridViewColumnType.ComboBox
		   Dim cp As ComboBoxProperties = TryCast(col.PropertiesEdit, ComboBoxProperties)
		   cp.ValueType = GetType(MVCxGridViewDataBinding.Models.MyModel.ModelStateEnum?)
		   col.Settings.FilterMode = ColumnFilterMode.Value
		   cp.DataSource = System.Enum.GetValues(GetType(MVCxGridViewDataBinding.Models.MyModel.ModelStateEnum))
		   cp.NullDisplayText = "[null]"
		   cp.ClientSideEvents.Init = "function(s,e) { s.InsertItem(0,'[null]','[null]') }"
    End Sub)
	Dim flag = False
	settings.AutoFilterCellEditorInitialize = Sub(s, e)
         Dim grid As MVCxGridView = TryCast(s, MVCxGridView)
		   If grid.FilterExpression.Contains("ModelState") AndAlso Session("text") IsNot Nothing AndAlso e.Column.FieldName="ModelState" Then
			   CType(e.Editor, ASPxComboBox).Text = TryCast(Session("text"), String)
		   End If	
        End Sub
	settings.ProcessColumnAutoFilter = Sub(s, e)
         If e.Kind = GridViewAutoFilterEventKind.CreateCriteria AndAlso e.Column.FieldName = "ModelState" Then
			   Dim str As String = TryCast(e.Value, String)
			   If str = "[null]" Then
				   flag = True
				   e.Criteria = New DevExpress.Data.Filtering.NullOperator("ModelState")
				   Session("text") = e.Value
			   Else
				   Session("text") = Nothing
			   End If
		   End If
		   If e.Kind = GridViewAutoFilterEventKind.ExtractDisplayText AndAlso e.Column.FieldName = "ModelState" AndAlso flag Then
			   flag = False
			   e.Value = "[null]"
		   End If
         End Sub
    End Sub).BindToEF(String.Empty,String.Empty, Sub(s,e) 
		e.QueryableSource = MVCxGridViewDataBinding.Models.MyModel.GetModelList().AsQueryable()
		e.KeyExpression = "ModelID"
		End Sub).GetHtml()



