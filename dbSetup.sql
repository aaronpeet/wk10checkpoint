CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS blogs(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title varchar(255) COMMENT 'blog title',
  body varchar(255) COMMENT 'blog body',
  imgUrl varchar(255) DEFAULT 'http://placehold.it/200x200' COMMENT'blog image',
  published TINYINT COMMENT 'is published',
  creatorId VARCHAR(255) NOT NULL COMMENT 'account Id of creator',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS comments(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  body varchar(255) COMMENT 'blog body',
  blogId INT NOT NULL COMMENT 'the blog ID that the comment was created on',
  creatorId VARCHAR(255) NOT NULL COMMENT 'account Id of creator',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (blogId) REFERENCES blogs(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';