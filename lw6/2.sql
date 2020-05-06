SELECT 
	download_count, 
	COUNT(*) AS user_count 
FROM ( 
    SELECT 
	COUNT(*) AS download_count  
    FROM track_downloads 
    WHERE download_time = '2010-11-19' 
    GROUP BY user_id)  
AS download_count
GROUP BY download_count; 