USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 3/3/2017 2:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[genre] [varchar](255) NULL,
	[song] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 3/3/2017 2:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues_bands]    Script Date: 3/3/2017 2:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues_bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]

GO
