USE [master]
GO
/****** Object:  Database [LibraryManagement]    Script Date: 10/29/2024 10:57:22 PM ******/
CREATE DATABASE [LibraryManagement]
USE [LibraryManagement]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 10/29/2024 10:57:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[role_id] [int] NOT NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[books]    Script Date: 10/29/2024 10:57:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cate_id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[title] [varchar](50) NULL,
	[description] [nvarchar](255) NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 10/29/2024 10:57:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rent_details]    Script Date: 10/29/2024 10:57:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rent_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rent_id] [int] NULL,
	[book_id] [int] NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_rent_details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rents]    Script Date: 10/29/2024 10:57:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[total_quatity] [int] NULL,
	[rent_time] [date] NULL,
	[return_time] [date] NULL,
	[status] [nvarchar](10) NULL,
 CONSTRAINT [PK_rents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 10/29/2024 10:57:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[accounts] ON 
GO
INSERT [dbo].[accounts] ([id], [username], [email], [password], [role_id], [status]) VALUES (1, N'admin', N'library.admin@gmail.com', N'12345678', 1, 1)
GO
INSERT [dbo].[accounts] ([id], [username], [email], [password], [role_id], [status]) VALUES (2, N'staff', N'library.staff@gmail.com', N'12345678', 2, 1)
GO
INSERT [dbo].[accounts] ([id], [username], [email], [password], [role_id], [status]) VALUES (3, N'thucnee123', N'ngocngocthuc@gmail.com', N'05112003', 3, 1)
GO
INSERT [dbo].[accounts] ([id], [username], [email], [password], [role_id], [status]) VALUES (7, N'hieuvuanguday', N'thehieu@gmail.com', N'12345678', 3, 0)
GO
INSERT [dbo].[accounts] ([id], [username], [email], [password], [role_id], [status]) VALUES (8, N'neru', N'neru@gmail.com', N'12345678', 3, 1)
GO
INSERT [dbo].[accounts] ([id], [username], [email], [password], [role_id], [status]) VALUES (9, N'thuchn', N'thuchnse171089@fpt.edu.vn', N'12345678', 3, 0)
GO
INSERT [dbo].[accounts] ([id], [username], [email], [password], [role_id], [status]) VALUES (10, N'hdiuuu', N'hoangdieu@gmail.com', N'12345678', 3, 0)
GO
INSERT [dbo].[accounts] ([id], [username], [email], [password], [role_id], [status]) VALUES (11, N'lilwin', N'thengdeng@gmail.com', N'12345678', 3, 0)
GO
INSERT [dbo].[accounts] ([id], [username], [email], [password], [role_id], [status]) VALUES (12, N'thucnee', N'thucnee@gmail.com', N'12345678', 3, 1)
GO
SET IDENTITY_INSERT [dbo].[accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[books] ON 
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (1, 1, N'To Kill a Mockingbird', N'Harper Lee', N'A novel about racial injustice in the South.', 10)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (2, 1, N'1984', N'George Orwell', N'A dystopian novel about surveillance and control.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (3, 1, N'The Great Gatsby', N'F. Scott Fitzgerald', N'A story about the American dream in the 1920s.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (4, 1, N'Moby-Dick', N'Herman Melville', N'A quest for vengeance against a giant whale.', 3)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (5, 1, N'Pride and Prejudice', N'Jane Austen', N'A classic romance in Georgian England.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (6, 1, N'The Catcher in the Rye', N'J.D. Salinger', N'A young man’s journey in New York.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (7, 1, N'Brave New World', N'Aldous Huxley', N'A dystopian novel on societal control.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (8, 1, N'Little Women', N'Louisa May Alcott', N'The lives of four sisters in New England.', 8)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (9, 1, N'The Scarlet Letter', N'Nathaniel Hawthorne', N'A story of guilt and redemption in Puritan America.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (10, 1, N'Frankenstein', N'Mary Shelley', N'The creation of a monster and its consequences.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (11, 2, N'Sapiens', N'Yuval Noah Harari', N'A history of humankind.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (12, 2, N'Educated', N'Tara Westover', N'A memoir of growing up isolated.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (13, 2, N'Becoming', N'Michelle Obama', N'The memoir of the former First Lady.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (14, 2, N'Unbroken', N'Laura Hillenbrand', N'A WWII survival story.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (15, 2, N'The Wright Brothers', N'David McCullough', N'The story of aviation pioneers.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (16, 2, N'The Immortal Life of Henrietta Lacks', N'Rebecca Skloot', N'A story of ethics and science.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (17, 2, N'Into Thin Air', N'Jon Krakauer', N'The tragedy on Mount Everest.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (18, 2, N'The Glass Castle', N'Jeannette Walls', N'A memoir of resilience.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (19, 2, N'The Devil in the White City', N'Erik Larson', N'Murder and mystery at the 1893 World’s Fair.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (20, 2, N'The Warmth of Other Suns', N'Isabel Wilkerson', N'The migration of African Americans.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (21, 3, N'A Brief History of Time', N'Stephen Hawking', N'A look at the universe and its nature.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (22, 3, N'Cosmos', N'Carl Sagan', N'Exploration of the universe.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (23, 3, N'The Selfish Gene', N'Richard Dawkins', N'The role of genes in evolution.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (24, 3, N'The Gene', N'Siddhartha Mukherjee', N'The story of the gene and its impact.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (25, 3, N'Astrophysics for People in a Hurry', N'Neil deGrasse Tyson', N'An accessible guide to astrophysics.', 8)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (26, 3, N'The Elegant Universe', N'Brian Greene', N'String theory and the fabric of space.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (27, 3, N'The Order of Time', N'Carlo Rovelli', N'A philosophical look at time.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (28, 3, N'The Hidden Life of Trees', N'Peter Wohlleben', N'The secret life of trees.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (29, 3, N'What If?', N'Randall Munroe', N'Serious scientific answers to absurd questions.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (30, 3, N'The Emperor of All Maladies', N'Siddhartha Mukherjee', N'A biography of cancer.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (31, 4, N'The World War II', N'Anthony Beevor', N'A comprehensive history of WWII.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (32, 4, N'The Silk Roads', N'Peter Frankopan', N'A new history of the world.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (33, 4, N'SPQR', N'Mary Beard', N'A history of ancient Rome.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (34, 4, N'Guns, Germs, and Steel', N'Jared Diamond', N'Exploration of societal development.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (35, 4, N'Team of Rivals', N'Doris Kearns Goodwin', N'The story of Lincoln and his cabinet.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (36, 4, N'The Diary of a Young Girl', N'Anne Frank', N'The story of Anne Frank during WWII.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (37, 4, N'The Rise and Fall of the Third Reich', N'William L. Shirer', N'A history of Nazi Germany.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (38, 4, N'A People’s History of the United States', N'Howard Zinn', N'The untold history of the USA.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (39, 4, N'The Civil War', N'Shelby Foote', N'A comprehensive look at the Civil War.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (40, 4, N'The Wright Brothers', N'David McCullough', N'The story of aviation pioneers.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (41, 5, N'Steve Jobs', N'Walter Isaacson', N'The biography of Apple’s co-founder.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (42, 5, N'The Diary of a Young Girl', N'Anne Frank', N'The story of a young Jewish girl.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (43, 5, N'Elon Musk', N'Ashlee Vance', N'The biography of Elon Musk.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (44, 5, N'Alexander Hamilton', N'Ron Chernow', N'A biography of the founding father.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (45, 5, N'Benjamin Franklin', N'Walter Isaacson', N'A comprehensive look at Franklin.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (46, 5, N'Churchill', N'Andrew Roberts', N'The life of Winston Churchill.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (47, 5, N'Einstein', N'Walter Isaacson', N'A biography of Albert Einstein.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (48, 5, N'Frida', N'Hayden Herrera', N'A biography of Frida Kahlo.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (49, 5, N'Gandhi', N'Ramachandra Guha', N'A biography of Mahatma Gandhi.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (50, 5, N'The Wright Brothers', N'David McCullough', N'The story of aviation pioneers.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (51, 6, N'The Innovators', N'Walter Isaacson', N'The story of digital revolutionaries.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (52, 6, N'Clean Code', N'Robert C. Martin', N'A guide to writing clean and efficient code.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (53, 6, N'The Pragmatic Programmer', N'Andrew Hunt & David Thomas', N'Tips and tools for software developers.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (54, 6, N'Code Complete', N'Steve McConnell', N'A comprehensive guide to software construction.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (55, 6, N'Artificial Intelligence: A Guide', N'Max Tegmark', N'An overview of AI and its implications.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (56, 6, N'The Art of Computer Programming', N'Donald Knuth', N'Foundational work on algorithms and computing.', 3)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (57, 6, N'Introduction to Algorithms', N'Thomas H. Cormen', N'A comprehensive resource on algorithms.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (58, 6, N'Machine Learning', N'Tom M. Mitchell', N'The fundamentals of machine learning.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (59, 6, N'Deep Learning', N'Ian Goodfellow', N'A comprehensive guide to deep learning.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (60, 6, N'Hackers', N'Steven Levy', N'The story of computer programming pioneers.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (61, 7, N'Meditations', N'Marcus Aurelius', N'Reflections from the Roman Emperor.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (62, 7, N'The Republic', N'Plato', N'A dialogue on justice and governance.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (63, 7, N'Beyond Good and Evil', N'Friedrich Nietzsche', N'A critique of traditional morality.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (64, 7, N'Critique of Pure Reason', N'Immanuel Kant', N'A foundational work in epistemology.', 3)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (65, 7, N'Thus Spoke Zarathustra', N'Friedrich Nietzsche', N'A philosophical novel on individualism.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (66, 7, N'The Art of Happiness', N'Epicurus', N'Ancient Greek views on happiness and peace.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (67, 7, N'On Liberty', N'John Stuart Mill', N'A defense of individual freedom.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (69, 7, N'Phenomenology of Spirit', N'Georg Hegel', N'A complex exploration of human experience.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (70, 7, N'The Tao Te Ching', N'Laozi', N'A classic Chinese text on philosophy and harmony.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (71, 8, N'Thinking, Fast and Slow', N'Daniel Kahneman', N'Insights into how we think and make decisions.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (72, 8, N'Man’s Search for Meaning', N'Viktor Frankl', N'A Holocaust survivor’s take on purpose.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (73, 8, N'The Power of Habit', N'Charles Duhigg', N'Exploration of the science of habits.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (74, 8, N'Grit', N'Angela Duckworth', N'Why passion and perseverance matter.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (75, 8, N'The Social Animal', N'David Brooks', N'A look at human behavior and relationships.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (77, 8, N'Outliers', N'Malcolm Gladwell', N'Understanding success and high achievers.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (78, 8, N'Emotional Intelligence', N'Daniel Goleman', N'The role of EQ in personal success.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (79, 8, N'The Interpretation of Dreams', N'Sigmund Freud', N'Foundational work on psychoanalysis.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (80, 8, N'The Lucifer Effect', N'Philip Zimbardo', N'Understanding the psychology of evil.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (81, 9, N'Good to Great', N'Jim Collins', N'What makes companies successful?', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (82, 9, N'Zero to One', N'Peter Thiel', N'Building the future with startups.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (83, 9, N'The Lean Startup', N'Eric Ries', N'A guide to modern entrepreneurial methods.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (84, 9, N'The Innovator’s Dilemma', N'Clayton Christensen', N'Why great companies fail.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (85, 9, N'The Hard Thing About Hard Things', N'Ben Horowitz', N'Lessons on entrepreneurship.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (86, 9, N'Blue Ocean Strategy', N'W. Chan Kim', N'Creating uncontested market space.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (87, 9, N'The Intelligent Investor', N'Benjamin Graham', N'Classic advice on value investing.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (88, 9, N'Principles', N'Ray Dalio', N'A comprehensive guide to life and work principles.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (89, 9, N'The 7 Habits of Highly Effective People', N'Stephen Covey', N'A popular self-help book for success.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (90, 9, N'Rich Dad Poor Dad', N'Robert Kiyosaki', N'A personal finance classic.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (91, 10, N'How to Win Friends and Influence People', N'Dale Carnegie', N'Time-tested principles for success.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (92, 10, N'Atomic Habits', N'James Clear', N'A guide to forming good habits.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (93, 10, N'The Power of Now', N'Eckhart Tolle', N'A guide to spiritual enlightenment.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (94, 10, N'The Four Agreements', N'Don Miguel Ruiz', N'Wisdom for a fulfilling life.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (95, 10, N'You Are a Badass', N'Jen Sincero', N'Tips for self-empowerment.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (96, 10, N'Daring Greatly', N'Brené Brown', N'The power of vulnerability.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (97, 10, N'Think and Grow Rich', N'Napoleon Hill', N'A classic on success and mindset.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (98, 10, N'The Secret', N'Rhonda Byrne', N'A guide to the law of attraction.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (99, 10, N'Awaken the Giant Within', N'Tony Robbins', N'Tools for self-improvement.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (100, 10, N'Can’t Hurt Me', N'David Goggins', N'A story of resilience and grit.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (101, 11, N'The Story of Art', N'E.H. Gombrich', N'A comprehensive history of art.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (102, 11, N'Ways of Seeing', N'John Berger', N'An exploration of art perception.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (103, 11, N'The Art Spirit', N'Robert Henri', N'Insights on creativity and art-making.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (104, 11, N'The War of Art', N'Steven Pressfield', N'Overcoming creative blocks.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (105, 11, N'History of Modern Art', N'H.H. Arnason', N'A detailed study of modern art.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (106, 11, N'Steal Like an Artist', N'Austin Kleon', N'Creative lessons for artists.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (107, 11, N'Art & Fear', N'David Bayles', N'Challenges of art-making.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (108, 11, N'Understanding Comics', N'Scott McCloud', N'Exploring the comics medium.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (109, 11, N'Color: A Natural History', N'Victoria Finlay', N'The story of color and its impact.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (110, 11, N'The Lives of Artists', N'Giorgio Vasari', N'Biographies of famous artists.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (111, 12, N'This Is Your Brain on Music', N'Daniel Levitin', N'The science of a human obsession.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (112, 12, N'The Rest Is Noise', N'Alex Ross', N'A journey through 20th-century music.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (113, 12, N'Musicophilia', N'Oliver Sacks', N'Tales of music and the brain.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (114, 12, N'How Music Works', N'David Byrne', N'Exploring the mechanics of music.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (115, 12, N'The Music Lesson', N'Victor Wooten', N'Spiritual lessons on music.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (116, 12, N'Our Band Could Be Your Life', N'Michael Azerrad', N'Indie rock in the 1980s.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (117, 12, N'Just Kids', N'Patti Smith', N'A memoir of art and music in New York.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (118, 12, N'The Power of Music', N'Elena Mannes', N'The influence of music on life.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (119, 12, N'Songwriters on Songwriting', N'Paul Zollo', N'Insights from famous songwriters.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (120, 12, N'Jazz', N'Gary Giddins & Scott DeVeaux', N'The story of jazz music.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (121, 13, N'Salt, Fat, Acid, Heat', N'Samin Nosrat', N'The essentials of cooking.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (122, 13, N'Mastering the Art of French Cooking', N'Julia Child', N'The fundamentals of French cuisine.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (123, 13, N'The Joy of Cooking', N'Irma Rombauer', N'A staple cookbook for home cooks.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (124, 13, N'The Food Lab', N'J. Kenji López-Alt', N'The science of home cooking.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (125, 13, N'Essentials of Classic Italian Cooking', N'Marcella Hazan', N'A guide to Italian cooking.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (126, 13, N'On Food and Cooking', N'Harold McGee', N'The science and lore of the kitchen.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (127, 13, N'Plenty', N'Yotam Ottolenghi', N'Creative vegetarian recipes.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (128, 13, N'Momofuku', N'David Chang', N'Asian-inspired recipes from the renowned chef.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (129, 13, N'The Flavor Bible', N'Karen Page', N'Pairing ingredients for flavor.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (130, 13, N'Simple', N'Yotam Ottolenghi', N'Easy, flavorful recipes.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (131, 14, N'A Brief History of Time', N'Stephen Hawking', N'Exploring the universe.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (132, 14, N'Cosmos', N'Carl Sagan', N'A journey through space and time.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (133, 14, N'The Selfish Gene', N'Richard Dawkins', N'Evolution from the gene''s perspective.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (134, 14, N'The Gene', N'Siddhartha Mukherjee', N'The history and impact of genetics.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (135, 14, N'Sapiens', N'Yuval Noah Harari', N'The story of humankind.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (136, 14, N'Astrophysics for People in a Hurry', N'Neil deGrasse Tyson', N'Quick insights on astrophysics.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (137, 14, N'The Immortal Life of Henrietta Lacks', N'Rebecca Skloot', N'The ethics of scientific progress.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (138, 14, N'Why We Sleep', N'Matthew Walker', N'The science of sleep and health.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (139, 14, N'The Emperor of All Maladies', N'Siddhartha Mukherjee', N'A biography of cancer.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (140, 14, N'The Elegant Universe', N'Brian Greene', N'String theory and beyond.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (141, 15, N'Gödel, Escher, Bach', N'Douglas Hofstadter', N'The interplay of math, art, and music.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (142, 15, N'Flatland', N'Edwin A. Abbott', N'A mathematical adventure in dimensions.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (143, 15, N'Fermat’s Enigma', N'Simon Singh', N'The story of a famous math problem.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (144, 15, N'The Man Who Knew Infinity', N'Robert Kanigel', N'A biography of Ramanujan.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (145, 15, N'The Joy of x', N'Steven Strogatz', N'Making math accessible.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (146, 15, N'In Pursuit of the Unknown', N'Ian Stewart', N'20 mathematical problems.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (147, 15, N'Mathematics for the Nonmathematician', N'Morris Kline', N'A layperson''s guide to math.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (148, 15, N'Infinite Powers', N'Steven Strogatz', N'The calculus revolution.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (149, 15, N'The Math Book', N'Clifford A. Pickover', N'Math milestones throughout history.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (150, 15, N'The Music of the Primes', N'Marcus du Sautoy', N'The mystery of prime numbers.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (151, 16, N'Guns, Germs, and Steel', N'Jared Diamond', N'The fates of human societies.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (152, 16, N'The Silk Roads', N'Peter Frankopan', N'A new history of the world.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (153, 16, N'SPQR', N'Mary Beard', N'A history of ancient Rome.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (154, 16, N'A People’s History of the United States', N'Howard Zinn', N'An alternate view of U.S. history.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (155, 16, N'The History of the Ancient World', N'Susan Wise Bauer', N'From the earliest accounts to the fall of Rome.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (156, 16, N'The Wright Brothers', N'David McCullough', N'The story of the Wright brothers.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (157, 16, N'The Diary of a Young Girl', N'Anne Frank', N'A WWII diary of survival.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (158, 16, N'The Crusades', N'Thomas Asbridge', N'A new look at the Crusades.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (159, 16, N'The Rise and Fall of the Third Reich', N'William Shirer', N'The history of Nazi Germany.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (160, 16, N'Team of Rivals', N'Doris Kearns Goodwin', N'The political genius of Abraham Lincoln.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (161, 17, N'Prisoners of Geography', N'Tim Marshall', N'Ten maps that explain the world.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (162, 17, N'The Power of Geography', N'Tim Marshall', N'Ten maps that shape our world.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (163, 17, N'Why Geography Matters', N'Harm de Blij', N'Understanding geopolitics and the environment.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (164, 17, N'Geographica', N'Fiona J. McDonald', N'A comprehensive atlas of the world.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (165, 17, N'Atlas of Remote Islands', N'Judith Schalansky', N'Fifty islands I have not visited and never will.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (166, 17, N'The Geography of Thought', N'Richard E. Nisbett', N'How East and West think differently.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (167, 17, N'Home: A Short History of an Idea', N'Witold Rybczynski', N'The concept of home in different cultures.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (168, 17, N'Longitude', N'Dava Sobel', N'The story of a lone genius who solved a great scientific problem.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (169, 17, N'The Revenge of Geography', N'Robert D. Kaplan', N'How geography shapes world events.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (170, 17, N'Maphead', N'Ken Jennings', N'A love letter to geography.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (171, 18, N'The Republic', N'Plato', N'A foundational philosophical work on justice.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (172, 18, N'Meditations', N'Marcus Aurelius', N'Stoic reflections on life and philosophy.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (173, 18, N'Beyond Good and Evil', N'Friedrich Nietzsche', N'A critique of traditional values.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (174, 18, N'The Critique of Pure Reason', N'Immanuel Kant', N'A key work in modern philosophy.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (175, 18, N'The Prince', N'Niccolò Machiavelli', N'Insights on political power.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (176, 18, N'Being and Time', N'Martin Heidegger', N'Exploration of existence.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (177, 18, N'A History of Western Philosophy', N'Bertrand Russell', N'An overview of Western philosophical thought.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (178, 18, N'Phenomenology of Spirit', N'G.W.F. Hegel', N'A work on consciousness and reality.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (179, 18, N'The Myth of Sisyphus', N'Albert Camus', N'Exploring the concept of the absurd.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (180, 18, N'The Art of War', N'Sun Tzu', N'Ancient wisdom on strategy and tactics.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (181, 19, N'Thinking, Fast and Slow', N'Daniel Kahneman', N'Exploring the two systems of thought.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (182, 19, N'The Interpretation of Dreams', N'Sigmund Freud', N'Foundational text on dream analysis.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (183, 19, N'Man and His Symbols', N'Carl Jung', N'Exploring the language of symbols.', 7)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (184, 19, N'Flow', N'Mihaly Csikszentmihalyi', N'The psychology of optimal experience.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (185, 19, N'Grit', N'Angela Duckworth', N'The power of passion and perseverance.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (186, 19, N'The Social Animal', N'Elliot Aronson', N'Examining human social behavior.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (187, 19, N'Influence', N'Robert Cialdini', N'The psychology of persuasion.', 5)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (188, 19, N'The Road Less Traveled', N'M. Scott Peck', N'A psychology of love and spiritual growth.', 4)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (189, 19, N'Quiet', N'Susan Cain', N'The power of introverts in a noisy world.', 6)
GO
INSERT [dbo].[books] ([id], [cate_id], [name], [title], [description], [quantity]) VALUES (190, 19, N'The Body Keeps the Score', N'Bessel van der Kolk', N'Trauma and its effects on the mind and body.', 7)
GO
SET IDENTITY_INSERT [dbo].[books] OFF
GO
SET IDENTITY_INSERT [dbo].[categories] ON 
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (1, N'Fiction')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (2, N'Non-Fiction')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (3, N'Science')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (4, N'History')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (5, N'Biography')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (6, N'Mystery')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (7, N'Fantasy')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (8, N'Technology')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (9, N'Romance')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (10, N'Thriller')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (11, N'Poetry')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (12, N'Children')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (13, N'Adventure')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (14, N'Philosophy')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (15, N'Self-Help')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (16, N'Health')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (17, N'Education')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (18, N'Reference')
GO
INSERT [dbo].[categories] ([id], [name]) VALUES (19, N'Religion')
GO
SET IDENTITY_INSERT [dbo].[categories] OFF
GO
SET IDENTITY_INSERT [dbo].[rent_details] ON 
GO
INSERT [dbo].[rent_details] ([id], [rent_id], [book_id], [quantity]) VALUES (3, NULL, 6, 1)
GO
INSERT [dbo].[rent_details] ([id], [rent_id], [book_id], [quantity]) VALUES (4, NULL, 12, 1)
GO
INSERT [dbo].[rent_details] ([id], [rent_id], [book_id], [quantity]) VALUES (5, NULL, 4, 1)
GO
INSERT [dbo].[rent_details] ([id], [rent_id], [book_id], [quantity]) VALUES (6, NULL, 9, 1)
GO
INSERT [dbo].[rent_details] ([id], [rent_id], [book_id], [quantity]) VALUES (7, NULL, 16, 1)
GO
INSERT [dbo].[rent_details] ([id], [rent_id], [book_id], [quantity]) VALUES (8, NULL, 30, 1)
GO
INSERT [dbo].[rent_details] ([id], [rent_id], [book_id], [quantity]) VALUES (9, NULL, 43, 1)
GO
INSERT [dbo].[rent_details] ([id], [rent_id], [book_id], [quantity]) VALUES (10, NULL, 7, 2)
GO
SET IDENTITY_INSERT [dbo].[rent_details] OFF
GO
SET IDENTITY_INSERT [dbo].[roles] ON 
GO
INSERT [dbo].[roles] ([id], [name]) VALUES (1, N'admin')
GO
INSERT [dbo].[roles] ([id], [name]) VALUES (2, N'staff')
GO
INSERT [dbo].[roles] ([id], [name]) VALUES (3, N'user')
GO
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
ALTER TABLE [dbo].[accounts] ADD  CONSTRAINT [DEFAULT_accounts_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[books] ADD  CONSTRAINT [DEFAULT_books_quantity]  DEFAULT ((1)) FOR [quantity]
GO
ALTER TABLE [dbo].[rents] ADD  CONSTRAINT [DEFAULT_rents_quantity]  DEFAULT ((1)) FOR [total_quatity]
GO
ALTER TABLE [dbo].[rents] ADD  CONSTRAINT [DEFAULT_rents_rent_time]  DEFAULT (getdate()) FOR [rent_time]
GO
ALTER TABLE [dbo].[rents] ADD  CONSTRAINT [DEFAULT_rents_return_time]  DEFAULT (NULL) FOR [return_time]
GO
ALTER TABLE [dbo].[rents] ADD  CONSTRAINT [DEFAULT_rents_status]  DEFAULT ('renting') FOR [status]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_roles]
GO
ALTER TABLE [dbo].[books]  WITH CHECK ADD  CONSTRAINT [FK_books_categories] FOREIGN KEY([cate_id])
REFERENCES [dbo].[categories] ([id])
GO
ALTER TABLE [dbo].[books] CHECK CONSTRAINT [FK_books_categories]
GO
ALTER TABLE [dbo].[rent_details]  WITH CHECK ADD  CONSTRAINT [FK_rent_details_books] FOREIGN KEY([book_id])
REFERENCES [dbo].[books] ([id])
GO
ALTER TABLE [dbo].[rent_details] CHECK CONSTRAINT [FK_rent_details_books]
GO
ALTER TABLE [dbo].[rent_details]  WITH CHECK ADD  CONSTRAINT [FK_rent_details_rents] FOREIGN KEY([rent_id])
REFERENCES [dbo].[rents] ([id])
GO
ALTER TABLE [dbo].[rent_details] CHECK CONSTRAINT [FK_rent_details_rents]
GO
ALTER TABLE [dbo].[rents]  WITH CHECK ADD  CONSTRAINT [FK_rents_accounts] FOREIGN KEY([user_id])
REFERENCES [dbo].[accounts] ([id])
GO
ALTER TABLE [dbo].[rents] CHECK CONSTRAINT [FK_rents_accounts]
GO
USE [master]
GO
ALTER DATABASE [LibraryManagement] SET  READ_WRITE 
GO
