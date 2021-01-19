import React, { useEffect, useState } from 'react';
import Post from './Post';

const PostForm = () => {
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        fetch('/api/post/add')
            .then(res => res.json())
            .then(data => setPosts(data));
    }, []);

    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="cards-column">
                    {posts.map((post) => (
                        <Post key={post.id} post={post} />
                    ))}
                </div>
            </div>
        </div>
    );
};

export default PostForm;