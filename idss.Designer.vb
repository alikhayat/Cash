<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class idss
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(idss))
        Me.fname = New System.Windows.Forms.Label()
        Me.lname = New System.Windows.Forms.Label()
        Me.type = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.first = New System.Windows.Forms.TextBox()
        Me.last = New System.Windows.Forms.TextBox()
        Me.idnumb = New System.Windows.Forms.TextBox()
        Me.birth = New System.Windows.Forms.TextBox()
        Me.exp = New System.Windows.Forms.TextBox()
        Me.idtype = New System.Windows.Forms.ComboBox()
        Me.phone = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.country = New System.Windows.Forms.ComboBox()
        Me.saved = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.middle = New System.Windows.Forms.Label()
        Me.middlee = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanNumb2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdssBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdssDataSet = New Cash.idssDataSet()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnSelectSource = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.scan = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.scan2 = New System.Windows.Forms.Label()
        Me.IdssTableAdapter = New Cash.idssDataSetTableAdapters.idssTableAdapter()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IdssBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IdssDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fname
        '
        Me.fname.AutoSize = True
        Me.fname.Location = New System.Drawing.Point(7, 9)
        Me.fname.Name = "fname"
        Me.fname.Size = New System.Drawing.Size(58, 13)
        Me.fname.TabIndex = 1
        Me.fname.Text = "First name:"
        '
        'lname
        '
        Me.lname.AutoSize = True
        Me.lname.Location = New System.Drawing.Point(6, 68)
        Me.lname.Name = "lname"
        Me.lname.Size = New System.Drawing.Size(59, 13)
        Me.lname.TabIndex = 2
        Me.lname.Text = "Last name:"
        '
        'type
        '
        Me.type.AutoSize = True
        Me.type.Location = New System.Drawing.Point(7, 97)
        Me.type.Name = "type"
        Me.type.Size = New System.Drawing.Size(44, 13)
        Me.type.TabIndex = 3
        Me.type.Text = "ID type:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "country"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Birth date:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Phone numb:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 205)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "exp date:"
        '
        'first
        '
        Me.first.Location = New System.Drawing.Point(77, 9)
        Me.first.Name = "first"
        Me.first.Size = New System.Drawing.Size(100, 20)
        Me.first.TabIndex = 8
        '
        'last
        '
        Me.last.Location = New System.Drawing.Point(77, 65)
        Me.last.Name = "last"
        Me.last.Size = New System.Drawing.Size(100, 20)
        Me.last.TabIndex = 10
        '
        'idnumb
        '
        Me.idnumb.Location = New System.Drawing.Point(77, 150)
        Me.idnumb.Name = "idnumb"
        Me.idnumb.Size = New System.Drawing.Size(100, 20)
        Me.idnumb.TabIndex = 13
        '
        'birth
        '
        Me.birth.Location = New System.Drawing.Point(77, 176)
        Me.birth.Name = "birth"
        Me.birth.Size = New System.Drawing.Size(100, 20)
        Me.birth.TabIndex = 14
        '
        'exp
        '
        Me.exp.Location = New System.Drawing.Point(77, 202)
        Me.exp.Name = "exp"
        Me.exp.Size = New System.Drawing.Size(100, 20)
        Me.exp.TabIndex = 15
        '
        'idtype
        '
        Me.idtype.BackColor = System.Drawing.SystemColors.Window
        Me.idtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.idtype.FormattingEnabled = True
        Me.idtype.Items.AddRange(New Object() {"national id", "passport", "military id", "residancy id", "syrian id", "other"})
        Me.idtype.Location = New System.Drawing.Point(77, 94)
        Me.idtype.Name = "idtype"
        Me.idtype.Size = New System.Drawing.Size(100, 21)
        Me.idtype.TabIndex = 11
        '
        'phone
        '
        Me.phone.Location = New System.Drawing.Point(77, 227)
        Me.phone.Name = "phone"
        Me.phone.Size = New System.Drawing.Size(100, 20)
        Me.phone.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "ID number:"
        '
        'country
        '
        Me.country.BackColor = System.Drawing.SystemColors.Window
        Me.country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.country.FormattingEnabled = True
        Me.country.Items.AddRange(New Object() {"Abkhazia", "Afghanistan", "Akrotiri and Dhekelia", "Aland", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Ascension Island", "Australia", "Austria", "Azerbaijan", "Bahamas, The", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central Africa Republic", "Chad", "Chile", "China", "Christmas Island", "Cocos (Keeling) Islands", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Cote d'lvoire", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Falkland Islands", "Faroe Islands", "Fiji", "Finland", "France", "French Polynesia", "Gabon", "Cambia, The", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guam", "Guatemala", "Guemsey", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Isle of Man", "Israel", "Italy", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea, N", "Korea, S", "Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macao", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Myanmar", "Nagorno-Karabakh", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Cyprus", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau", "Palestine", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Pitcaim Islands", "Poland", "Portugal", "Puerto Rico", "Qatar", "Romania", "Russia", "Rwanda", "Sahrawi Arab Democratic Republic", "Saint-Barthelemy", "Saint Helena", "Saint Kitts and Nevis", "Saint Lucia", "Saint Martin", "Saint Pierre and Miquelon", "Saint Vincent and Grenadines", "Samos", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "Somaliland", "South Africa", "South Ossetia", "Spain", "Sri Lanka", "Sudan", "Suriname", "Svalbard", "Swaziland", "Sweden", "Switzerland", "Syria", "Tajikistan", "Tanzania", "Thailand", "Togo", "Tokelau", "Tonga", "Transnistria", "Trinidad and Tobago", "Tristan da Cunha", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "Virgin Islands, British", "Virgin Islands, U.S.", "Wallis and Futuna", "Yemen", "Zambia", "Zimbabwe"})
        Me.country.Location = New System.Drawing.Point(77, 121)
        Me.country.Name = "country"
        Me.country.Size = New System.Drawing.Size(100, 21)
        Me.country.TabIndex = 12
        '
        'saved
        '
        Me.saved.Location = New System.Drawing.Point(202, 255)
        Me.saved.Name = "saved"
        Me.saved.Size = New System.Drawing.Size(75, 23)
        Me.saved.TabIndex = 18
        Me.saved.Text = "save"
        Me.saved.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 257)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "scan number:"
        '
        'middle
        '
        Me.middle.AutoSize = True
        Me.middle.Location = New System.Drawing.Point(7, 40)
        Me.middle.Name = "middle"
        Me.middle.Size = New System.Drawing.Size(40, 13)
        Me.middle.TabIndex = 18
        Me.middle.Text = "middle:"
        '
        'middlee
        '
        Me.middlee.Location = New System.Drawing.Point(77, 37)
        Me.middlee.Name = "middlee"
        Me.middlee.Size = New System.Drawing.Size(100, 20)
        Me.middlee.TabIndex = 9
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(875, 153)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 20
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(875, 176)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 21
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(875, 206)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(795, 157)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "First name:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(813, 183)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "middle:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(795, 209)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Last name:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(758, 261)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 17)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "search found:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(871, 258)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 20)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "0"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(375, 255)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "1st scan"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.ScanNumb2DataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.IdssBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(6, 310)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1016, 194)
        Me.DataGridView1.TabIndex = 29
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "name"
        Me.DataGridViewTextBoxColumn11.HeaderText = "name"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "middle"
        Me.DataGridViewTextBoxColumn12.HeaderText = "middle"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "lastName"
        Me.DataGridViewTextBoxColumn13.HeaderText = "lastName"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "id type"
        Me.DataGridViewTextBoxColumn14.HeaderText = "id type"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "country"
        Me.DataGridViewTextBoxColumn15.HeaderText = "country"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "id number"
        Me.DataGridViewTextBoxColumn16.HeaderText = "id number"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "birthday"
        Me.DataGridViewTextBoxColumn17.HeaderText = "birthday"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "exp date"
        Me.DataGridViewTextBoxColumn18.HeaderText = "exp date"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "phoneNumber"
        Me.DataGridViewTextBoxColumn19.HeaderText = "phoneNumber"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "scan numb"
        Me.DataGridViewTextBoxColumn20.HeaderText = "scan numb"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'ScanNumb2DataGridViewTextBoxColumn
        '
        Me.ScanNumb2DataGridViewTextBoxColumn.DataPropertyName = "scan numb 2"
        Me.ScanNumb2DataGridViewTextBoxColumn.HeaderText = "scan numb 2"
        Me.ScanNumb2DataGridViewTextBoxColumn.Name = "ScanNumb2DataGridViewTextBoxColumn"
        Me.ScanNumb2DataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdssBindingSource
        '
        Me.IdssBindingSource.DataMember = "idss"
        Me.IdssBindingSource.DataSource = Me.IdssDataSet
        '
        'IdssDataSet
        '
        Me.IdssDataSet.DataSetName = "idssDataSet"
        Me.IdssDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(202, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(270, 234)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'btnSelectSource
        '
        Me.btnSelectSource.Location = New System.Drawing.Point(456, 255)
        Me.btnSelectSource.Name = "btnSelectSource"
        Me.btnSelectSource.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectSource.TabIndex = 32
        Me.btnSelectSource.Text = "2nd scan"
        Me.btnSelectSource.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(795, 234)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "phone numb:"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(875, 230)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 23
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(489, 9)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(284, 234)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        '
        'scan
        '
        Me.scan.AutoSize = True
        Me.scan.Location = New System.Drawing.Point(74, 260)
        Me.scan.Name = "scan"
        Me.scan.Size = New System.Drawing.Size(0, 13)
        Me.scan.TabIndex = 35
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 283)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "scan number:"
        '
        'scan2
        '
        Me.scan2.AutoSize = True
        Me.scan2.Location = New System.Drawing.Point(74, 283)
        Me.scan2.Name = "scan2"
        Me.scan2.Size = New System.Drawing.Size(0, 13)
        Me.scan2.TabIndex = 37
        '
        'IdssTableAdapter
        '
        Me.IdssTableAdapter.ClearBeforeFill = True
        '
        'idss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(1011, 516)
        Me.Controls.Add(Me.scan2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.scan)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnSelectSource)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.middlee)
        Me.Controls.Add(Me.middle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.saved)
        Me.Controls.Add(Me.country)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.phone)
        Me.Controls.Add(Me.idtype)
        Me.Controls.Add(Me.exp)
        Me.Controls.Add(Me.birth)
        Me.Controls.Add(Me.idnumb)
        Me.Controls.Add(Me.last)
        Me.Controls.Add(Me.first)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.type)
        Me.Controls.Add(Me.lname)
        Me.Controls.Add(Me.fname)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "idss"
        Me.Text = "ids"
        Me.TransparencyKey = System.Drawing.Color.Silver
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IdssBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IdssDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fname As System.Windows.Forms.Label
    Friend WithEvents lname As System.Windows.Forms.Label
    Friend WithEvents type As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents first As System.Windows.Forms.TextBox
    Friend WithEvents last As System.Windows.Forms.TextBox
    Friend WithEvents idnumb As System.Windows.Forms.TextBox
    Friend WithEvents birth As System.Windows.Forms.TextBox
    Friend WithEvents exp As System.Windows.Forms.TextBox
    Friend WithEvents idtype As System.Windows.Forms.ComboBox
    Friend WithEvents phone As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents country As System.Windows.Forms.ComboBox
    Friend WithEvents saved As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents middle As System.Windows.Forms.Label
    Friend WithEvents middlee As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button


    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MiddleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CountryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BirthdayDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PhoneNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanNumbDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn


    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView


    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Field1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSelectSource As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents scan As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents scan2 As System.Windows.Forms.Label
    Friend WithEvents IdssDataSet As Cash.idssDataSet
    Friend WithEvents IdssBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IdssTableAdapter As Cash.idssDataSetTableAdapters.idssTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanNumb2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
