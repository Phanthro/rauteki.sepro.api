USE [Fire01]
GO
/****** Object:  User [FireApp]    Script Date: 01/03/2024 15:32:48 ******/
CREATE USER [FireApp] FOR LOGIN [FireApp] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[CCIRDominio]    Script Date: 01/03/2024 15:32:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCIRDominio](
	[Tipo] [varchar](20) NULL,
	[Codigo] [varchar](3) NULL,
	[Descricao] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CCIRTipoDominio]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CCIRTipoDominio](
	[CCIRTipoDominioId] [int] NULL,
	[Descricao] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[NumeroInscricao] [varchar](75) NOT NULL,
	[TipoInscricao] [varchar](2) NOT NULL,
	[Nome] [varchar](75) NOT NULL,
	[Sobrenome] [varchar](75) NOT NULL,
	[RazaoSocial] [varchar](75) NOT NULL,
	[DataNascimento] [varchar](75) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClienteCredito]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteCredito](
	[ClienteId] [int] NOT NULL,
	[Credito] [decimal](18, 2) NOT NULL,
	[AtualizadoEm] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClienteCreditoHistórico]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteCreditoHistórico](
	[ClienteId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[TipoOperacao] [int] NOT NULL,
	[EfetuadoEm] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClienteDetalhe]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClienteDetalhe](
	[ClienteDetalheId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[NomeContato] [varchar](50) NULL,
	[Telefone] [varchar](50) NULL,
	[Celular] [varchar](50) NULL,
	[WhatsApp] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[ProdutoInteressado] [varchar](50) NULL,
	[ComoConheceu] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ClienteDetalhe] PRIMARY KEY CLUSTERED 
(
	[ClienteDetalheId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClienteEndereco]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ClienteEndereco](
	[ClienteEnderecoId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[NomeEndereco] [varchar](50) NULL,
	[Endereco] [varchar](100) NOT NULL,
	[Numero] [varchar](100) NOT NULL,
	[Complemento] [varchar](100) NULL,
	[CEP] [varchar](50) NULL,
	[Cidade] [varchar](70) NULL
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[ClienteEndereco] ADD [Bairro] [varchar](70) NULL
 CONSTRAINT [PK_ClienteEndereco] PRIMARY KEY CLUSTERED 
(
	[ClienteEnderecoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CNPJDominio]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CNPJDominio](
	[Tipo] [varchar](20) NULL,
	[Codigo] [varchar](3) NULL,
	[Descricao] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CNPJTipoDominio]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CNPJTipoDominio](
	[CNPJTipoDominioId] [int] NULL,
	[Descricao] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Consulta](
	[ConsultaId] [int] NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Descricao] [varchar](200) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[link] [varchar](50) NOT NULL,
	[ItemPai] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FaleConoscoContato]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FaleConoscoContato](
	[FaleConoscoContatoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](75) NOT NULL,
	[Sobrenome] [varchar](75) NOT NULL,
	[Email] [varchar](75) NOT NULL,
	[Telefone] [varchar](15) NOT NULL,
	[Assunto] [varchar](30) NOT NULL,
	[Comentario] [varchar](300) NOT NULL,
	[RecebidoEm] [datetime] NOT NULL,
	[VistoEm] [datetime] NULL,
	[ExcluidoEm] [datetime] NULL,
 CONSTRAINT [PK_FaloConoscoContato] PRIMARY KEY CLUSTERED 
(
	[FaleConoscoContatoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoOperacao]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoOperacao](
	[TipoOperacaoId] [int] NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Descricao] [varchar](200) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Email] [varchar](300) NULL,
	[Senha] [varchar](100) NOT NULL,
	[Nome] [varchar](75) NOT NULL,
	[CriadoEm] [datetime] NOT NULL,
	[IsAtivo] [bit] NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC,
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioConsultaHistorico]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioConsultaHistorico](
	[ConsultaHistoricoId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[ConsultaId] [int] NOT NULL,
	[Cpf] [varchar](20) NOT NULL,
	[Requisicao] [varchar](max) NOT NULL,
	[Resposta] [varchar](max) NOT NULL,
	[RealizadoEm] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioConta]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioConta](
	[UsuarioId] [int] NOT NULL,
	[TokenReset] [varchar](10) NULL,
	[IsPrimeiroAcesso] [bit] NOT NULL,
	[Telefone] [varchar](300) NULL,
UNIQUE NONCLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioCredito]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioCredito](
	[UsuarioId] [int] NOT NULL,
	[Credito] [decimal](18, 2) NOT NULL,
	[AtualizadoEm] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioCreditoHistórico]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioCreditoHistórico](
	[UsuarioId] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[TipoOperacao] [int] NOT NULL,
	[EfetuadoEm] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioPermissaoPagina]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPermissaoPagina](
	[UsuarioId] [int] NOT NULL,
	[PaginaId] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioPermissaoPagina] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC,
	[PaginaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ClienteDetalhe]  WITH CHECK ADD  CONSTRAINT [FK_ClienteDetalhe_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[ClienteDetalhe] CHECK CONSTRAINT [FK_ClienteDetalhe_Cliente]
GO
ALTER TABLE [dbo].[ClienteEndereco]  WITH CHECK ADD  CONSTRAINT [FK_ClienteEndereco_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[ClienteEndereco] CHECK CONSTRAINT [FK_ClienteEndereco_Cliente]
GO
/****** Object:  StoredProcedure [dbo].[Cliente_Atualiza_Credito]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-12-08
-- Description:	Atualizar creditos cliente
-- =============================================
CREATE   PROCEDURE [dbo].[Cliente_Atualiza_Credito]
	@clienteId  int,
	@valor  decimal(18,2)
AS
BEGIN

	update 
		[dbo].[ClienteCredito]
	SET 
		Credito = @valor
	WHERE
		[ClienteId] = @clienteId
END


GO
/****** Object:  StoredProcedure [dbo].[Cliente_CriarNovo]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-11-07
-- Description:	Criar novo cliente
-- =============================================
CREATE   PROCEDURE [dbo].[Cliente_CriarNovo]
	@NumeroInscricao  varchar(75),
	@Tipoinscricao varchar(2),
	@Nome varchar(75),
	@DataNascimento varchar(75),
	@Sobrenome varchar(75),
	@RazaoSocial varchar(75)

AS
BEGIN
	INSERT INTO [dbo].[Cliente]
           ([NumeroInscricao]
           ,[TipoInscricao]
           ,[Nome]
		   ,[DataNascimento]
           ,[Sobrenome]
           ,[RazaoSocial])
     VALUES
           (@NumeroInscricao
           ,@Tipoinscricao
           ,@Nome
		   ,@DataNascimento
           ,@Sobrenome
           ,@RazaoSocial)
END

SELECT Convert(int, SCOPE_IDENTITY())


GO
/****** Object:  StoredProcedure [dbo].[Cliente_Obter_Creditos]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-12-07
-- Description:	Obter creditos cliente
-- =============================================
CREATE    PROCEDURE [dbo].[Cliente_Obter_Creditos]
	@ClienteId  int
AS
BEGIN

	SELECT top 1
		[Credito]
	FROM
		[Fire01].[dbo].[ClienteCredito]
	WHERE
		[ClienteId] = @ClienteId
END


GO
/****** Object:  StoredProcedure [dbo].[Cliente_Salvar_ConsultaHistorico]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-11-07
-- Description:	Salva consulta historico cliente
-- =============================================
CREATE     PROCEDURE [dbo].[Cliente_Salvar_ConsultaHistorico]
	@clienteId int,
	@usuarioId int,
	@valor decimal,
	@tipoOperacao int
AS
BEGIN

	INSERT INTO [dbo].[ClienteCreditoHistórico] VALUES
	(@clienteId, @usuarioId, @valor, @tipoOperacao, getdate())


END


GO
/****** Object:  StoredProcedure [dbo].[ClienteDetalhe_CriarNovo]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-11-07
-- Description:	Criar detalhes para um cliente
-- =============================================
CREATE   PROCEDURE [dbo].[ClienteDetalhe_CriarNovo]
	@ClienteId  int,
	@NomeContato varchar(2),
	@Telefone varchar(75),
	@Celular varchar(75),
	@WhatsApp varchar(75),
	@Email varchar(75),
	@ProdutoInteressado varchar(75),
	@ComoConheceu varchar(75)

AS
BEGIN
	INSERT INTO [dbo].[ClienteDetalhe]
           ([ClienteId]
           ,[NomeContato]
           ,[Telefone]
           ,[Celular]
           ,[WhatsApp]
           ,[Email]
           ,[ProdutoInteressado]
           ,[ComoConheceu])
     VALUES
           (@ClienteId
           ,@NomeContato
           ,@Telefone
           ,@Celular
           ,@WhatsApp
           ,@Email
           ,@ProdutoInteressado
           ,@ComoConheceu)
END

SELECT Convert(int, SCOPE_IDENTITY())


GO
/****** Object:  StoredProcedure [dbo].[ClienteEndereco_CriarNovo]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-11-07
-- Description:	Criar novo endereço para um cliente
-- =============================================
CREATE   PROCEDURE [dbo].[ClienteEndereco_CriarNovo]
	@ClienteId  int,
	@NomeEndereco varchar(75),
	@Endereco varchar(75),
	@Numero varchar(75),
	@Complemento varchar(75),
	@CEP varchar(75),
	@Cidade varchar(75),
	@Bairro varchar(75)

AS
BEGIN
	INSERT INTO [dbo].[ClienteEndereco]
           ([ClienteId]
           ,[NomeEndereco]
           ,[Endereco]
           ,[Numero]
           ,[Complemento]
           ,[CEP]
           ,[Cidade]
		   ,[Bairro])
     VALUES
           (@ClienteId
           ,@NomeEndereco
           ,@Endereco
           ,@Numero
           ,@Complemento
           ,@CEP
           ,@Cidade
		   ,@bairro)
END

SELECT Convert(int, SCOPE_IDENTITY())



GO
/****** Object:  StoredProcedure [dbo].[Consultas_Obter_Consultas]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-11-07
-- Description:	Obter consultas disponíveis
-- =============================================
CREATE PROCEDURE [dbo].[Consultas_Obter_Consultas]
AS
BEGIN

	SELECT 
		[ConsultaId]
		,[Nome]
		,[Descricao]
		,[Valor]
		,[Link]
		,[ItemPai]
	FROM 
		[Fire01].[dbo].[Consulta]


END

GO
/****** Object:  StoredProcedure [dbo].[Consultas_Obter_UsuarioHistorico]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-11-07
-- Description:	Obter consulta historico usuario
-- =============================================
CREATE       PROCEDURE [dbo].[Consultas_Obter_UsuarioHistorico]
	@usuarioId int = 0,
	@ConsultaHistoricoId int = 0
AS
BEGIN

	SELECT 
		uch.ConsultaHistoricoId
	  ,	uch.[ConsultaId]
	  , u.[Nome] 'NomeUsuario'
      , c.[Nome] 'NomeConsulta'
      , [Cpf]
	  , CASE  WHEN @ConsultaHistoricoId <> 0
			   THEN [Requisicao]
			   ELSE ''
			  END AS 'Requisicao'
	  , CASE  WHEN @ConsultaHistoricoId <> 0
			   THEN [Resposta]
			   ELSE ''
			  END AS 'Resposta'
      , [RealizadoEm]
  FROM 
		[Fire01].[dbo].[UsuarioConsultaHistorico] uch
		  INNER JOIN [dbo].[Usuario] u ON u.[UsuarioId] = uch.[UsuarioId]
		  INNER JOIN [dbo].[Consulta] c ON c.[ConsultaId] = uch.[ConsultaId]

  WHERE
	(@usuarioId = 0 OR uch.UsuarioId = @usuarioId)
	AND
	(@ConsultaHistoricoId = 0 OR uch.[ConsultaHistoricoId] = @ConsultaHistoricoId)

  ORDER BY
	[RealizadoEm] DESC
	

END


GO
/****** Object:  StoredProcedure [dbo].[Consultas_Salvar_ConsultaHistorico]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-11-07
-- Description:	Salva consulta historico
-- =============================================
CREATE   PROCEDURE [dbo].[Consultas_Salvar_ConsultaHistorico]
	@consultaId int,
	@usuarioId int,
	@cpf varchar(20),
	@requisicao varchar(max),
	@resposta varchar(max)
AS
BEGIN

	INSERT INTO [dbo].[UsuarioConsultaHistorico] VALUES
	(@usuarioId, @consultaId, @cpf, @requisicao, @resposta, getdate())


END


GO
/****** Object:  StoredProcedure [dbo].[Dominios_Obter_CNPJ]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2024-02-10
-- Description:	Obter definições de campo de CNPJ
-- =============================================
CREATE   PROCEDURE [dbo].[Dominios_Obter_CNPJ]
AS
BEGIN

	SELECT td.[CNPJTipoDominioId] 'Tipo'
		,td.[Descricao] 'DescricaoTipo'
		,d.[Codigo] 'CodigoCampo'
		,d.[Descricao] 'DescricaoCampo'
	FROM [dbo].[CNPJDominio] d
		INNER JOIn [dbo].[CNPJTipoDominio] td
			ON d.Tipo = td.CNPJTipoDominioId


END

GO
/****** Object:  StoredProcedure [dbo].[FaleConosco_GravarNovoContato]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-11-09
-- Description:	Criar novo contato homepage
-- =============================================
CREATE     PROCEDURE [dbo].[FaleConosco_GravarNovoContato]
	@Nome varchar(75),
	@Sobrenome varchar(75),
	@Email varchar(75),
	@Telefone  varchar(75),
	@Assunto varchar(30),
	@Comentario varchar(300)

AS
BEGIN
	INSERT INTO [dbo].[FaleConoscoContato]
           ([Nome]
           ,[Sobrenome]
           ,[Email]
		   ,[Telefone]
           ,[Assunto]
		   ,[Comentario]
		   ,[RecebidoEm])
     VALUES
           (@Nome
           ,@Sobrenome
           ,@Email
		   ,@Telefone
		   ,@Assunto
           ,@Comentario
           ,GETDATE())
END

SELECT Convert(int, SCOPE_IDENTITY())





GO
/****** Object:  StoredProcedure [dbo].[Usuario_Alterar_Usuario]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2024-02-26
-- Description:	Atualizar dados do usuario
-- =============================================
CREATE     PROCEDURE [dbo].[Usuario_Alterar_Usuario]
	@UsuarioId  int,
	@Email  varchar(150),
	@Nome varchar(75),
	@Senha varchar(75),
	@Telefone varchar(300)

AS
BEGIN
	UPDATE [dbo].[Usuario]
    SET [Nome] = @Nome
    WHERE
		[UsuarioId] = @UsuarioId

	IF (@Senha <> '' AND @Senha <> NULL)
		BEGIN
			UPDATE
				[dbo].[Usuario] 
			SET
				[Senha] = @Senha
			WHERE
				[UsuarioId] = @UsuarioId
		END

	UPDATE [dbo].[UsuarioConta] 
	SET [Telefone] = @Telefone 
	WHERE [UsuarioId] = @UsuarioId
END



GO
/****** Object:  StoredProcedure [dbo].[Usuario_Atualiza_Credito]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2024-03-01
-- Description:	Atualizar creditos usuario
-- =============================================
CREATE     PROCEDURE [dbo].[Usuario_Atualiza_Credito]
	@usuarioId  int,
	@valor  decimal(18,2)
AS
BEGIN

	update 
		[dbo].[UsuarioCredito]
	SET 
		Credito = @valor
	WHERE
		[UsuarioId] = @usuarioId
END


GO
/****** Object:  StoredProcedure [dbo].[Usuario_Inserir_Usuario]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2024-02-26
-- Description:	Criar novo usuario
-- =============================================
CREATE   PROCEDURE [dbo].[Usuario_Inserir_Usuario]
	@ClienteId  int,
	@Email  varchar(150),
	@Nome varchar(75),
	@Senha varchar(75),
	@CriadoEm varchar(20),
	@Telefone varchar(20)

AS
BEGIN
	INSERT INTO [dbo].[Usuario]
           ([ClienteId]
           ,[Email]
           ,[Senha]
           ,[Nome]
           ,[CriadoEm]
           ,[IsAtivo])
     VALUES
           (@ClienteId
           ,@Email
           ,@Senha
           ,@Nome
           ,@CriadoEm
           ,1)

	INSERT INTO [dbo].[UsuarioConta] VALUES(Convert(int, SCOPE_IDENTITY()), '', 1, @Telefone)
	INSERT INTO [dbo].[UsuarioCredito] VALUES  (Convert(int, SCOPE_IDENTITY()), 0, getdate())
END



GO
/****** Object:  StoredProcedure [dbo].[Usuario_Listar_PorClienteId]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2024-02-26
-- Description:	Obter lista de usuario por cliente
-- =============================================
CREATE     PROCEDURE [dbo].[Usuario_Listar_PorClienteId]
	@clienteId int
AS
BEGIN

	SELECT 
		[UsuarioId]
		,[ClienteId]
		,[Email]
		,[Senha]
		,[Nome]
		,[CriadoEm]
		,[IsAtivo]
	FROM 
		[Fire01].[dbo].[Usuario]
	WHERE
		[ClienteId] = @clienteId
	ORDER BY
		[Nome]
END

SELECT Convert(int, SCOPE_IDENTITY())


GO
/****** Object:  StoredProcedure [dbo].[Usuario_Obter_Creditos]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-12-07
-- Description:	Obter creditos usuario
-- =============================================
CREATE      PROCEDURE [dbo].[Usuario_Obter_Creditos]
	@UsuarioId  int
AS
BEGIN

	SELECT top 1
		[Credito]
	FROM
		[Fire01].[dbo].[UsuarioCredito]
	WHERE
		[UsuarioId] = @UsuarioId
END


GO
/****** Object:  StoredProcedure [dbo].[Usuario_Obter_PermissoesPagina]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-11-14
-- Description:	Obter lista de permissões de pagina de um usuario
-- =============================================
CREATE   PROCEDURE [dbo].[Usuario_Obter_PermissoesPagina]
	@UsuarioId  int
AS
BEGIN

	SELECT 
	   [UsuarioId]
      ,[PaginaId]
	FROM
		[Fire01].[dbo].[UsuarioPermissaoPagina]
	WHERE
		[UsuarioId] = @UsuarioId
END


GO
/****** Object:  StoredProcedure [dbo].[Usuario_Obter_PorEmail]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2023-11-07
-- Description:	Obter usuario por email
-- =============================================
CREATE   PROCEDURE [dbo].[Usuario_Obter_PorEmail]
	@Email  varchar(75)
AS
BEGIN

	SELECT TOP 1
		[UsuarioId]
		,[ClienteId]
		,[Email]
		,[Senha]
		,[Nome]
		,[CriadoEm]
		,[IsAtivo]
	FROM 
		[Fire01].[dbo].[Usuario]
	WHERE
		[Email] = @Email
END

SELECT Convert(int, SCOPE_IDENTITY())


GO
/****** Object:  StoredProcedure [dbo].[Usuario_Obter_PorUsuarioId]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2024-02-29
-- Description:	Obter usuario por id
-- =============================================
CREATE   PROCEDURE [dbo].[Usuario_Obter_PorUsuarioId]
	@UsuarioId int
AS
BEGIN

	SELECT TOP 1
		u.[UsuarioId]
		,[ClienteId]
		,[Email]
		,[Senha]
		,[Nome]
		,[CriadoEm]
		, uc.Telefone
		,[IsAtivo]
	FROM 
		[Fire01].[dbo].[Usuario] u
		INNER JOIN [Fire01].[dbo].[UsuarioConta] uc on u.UsuarioId = uc.UsuarioId
	WHERE
		u.[UsuarioId] = @UsuarioId
END



GO
/****** Object:  StoredProcedure [dbo].[Usuario_Salvar_ConsultaHistorico]    Script Date: 01/03/2024 15:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Bruno Buchar Montenegro
-- Create date: 2024-03-01
-- Description:	Salva consulta historico usuario
-- =============================================
CREATE   PROCEDURE [dbo].[Usuario_Salvar_ConsultaHistorico]
	@usuarioId int,
	@valor decimal,
	@tipoOperacao int
AS
BEGIN

	INSERT INTO [dbo].[UsuarioCreditoHistórico] VALUES
	(@usuarioId, @valor, @tipoOperacao, getdate())


END


GO
