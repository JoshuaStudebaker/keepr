-- CREATE TABLE IF NOT EXISTS profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

-- SELECT * FROM profiles

CREATE TABLE keeps(
  id int AUTO_INCREMENT,
  creatorId VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) DEFAULT "No description available",
  img VARCHAR(255) DEFAULT "https://images.unsplash.com/photo-1470104240373-bc1812eddc9f?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
  views int DEFAULT 0,
  shares int DEFAULT 0,
  keeps int DEFAULT 0,

  
--   PRIMARY KEY (id),
--   FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- )

-- INSERT INTO keeps
-- (creatorId, name, description, img)
-- VALUES
-- ("8700cd9b-3848-4114-9936-c047349efa80", "First Ever Keep", "MySql is amazing", "https://images.unsplash.com/photo-1534143046043-44af3469836b?ixlib=rb-1.2.1&auto=format&fit=crop&w=700&q=80")

-- INSERT INTO keeps
-- (creatorId, name, img)
-- VALUES
-- ("8700cd9b-3848-4114-9936-c047349efa80", "Second Ever Keep","https://images.unsplash.com/photo-1470104240373-bc1812eddc9f?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80" )

-- SELECT * FROM keeps




