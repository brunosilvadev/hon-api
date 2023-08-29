CREATE TABLE Card
(
    `CardId` int NOT NULL,
    `CardName` varchar(256) NOT NULL,
    `CardContent` varchar(2048) ,
    `CategoryId` int,
    `ReminderId` int,
    PRIMARY KEY (CardId)
)



ALTER TABLE `Card`
ADD CONSTRAINT `fk_CategoryId`
FOREIGN KEY (`CategoryId`) REFERENCES `Category`(`CategoryId`)
ON DELETE SET NULL
ON UPDATE CASCADE;

ALTER TABLE `Card`
ADD CONSTRAINT `fk_ReminderId`
FOREIGN KEY (`ReminderId`) REFERENCES `Reminder`(`ReminderId`)
ON DELETE SET NULL
ON UPDATE CASCADE;


insert Card (CardId,CardName,CardContent,CategoryId)
Values (1,'Filter change','Remember to change your filter every 90 days',0)