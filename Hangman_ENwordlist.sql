use WordLists

select * from WordListEN where Word like '_' or Word like '__' or Word like '___'
delete from WordListEN where Word like '_' or Word like '__' or Word like '___'

--Find and display duplicate rows with the number of repititions
select Word, count(*) as CNT from WordListEN
group by Word having count(*) > 1

--Add an ID column; numbers are added automatically
alter table WordListEN
add WordID int not null identity primary key

select Word from WordListEN

--6527 rows in cleaned table.