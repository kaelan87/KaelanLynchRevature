INSERT INTO ACCOUNTS VALUES
('87', 'Kaelan Lynch', 'Checking', '1000', 'True', 'kaelan@gmail.com');

select * FROM ACCOUNTS

ALTER TABLE Login 
ADD accNo Int

ALTER TABLE Login
ADD FOREIGN KEY (accNo) REFERENCES ACCOUNTS(accNo);

ALTER TABLE ACCOUNTS
ADD PRIMARY KEY (accNo)

SELECT * FROM ACCOUNTS

DELETE FROM ACCOUNTS WHERE accNo='0'

DELETE FROM Login WHERE userName= 'katie'
DELETE FROM Login WHERE userName= 'elan'

DELETE FROM Login WHERE accNo = '87'

INSERT INTO LOGIN (accNo)
VALUES ('87')

UPDATE Login
SET accNo= '87'
WHERE userName= 'kaelan'