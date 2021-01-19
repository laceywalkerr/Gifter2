import React, { useEffect, useState } from 'react';
import PostSearch from './PostSearch';

const PostList = () => {
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        fetch('/api/post')
            .then(res => res.json())
            .then(data => setPosts(data));
    }, []);

    return (
        <div className="container">
            <div className="row justify-content-center">
                {/* <div className="cards-column"> */}
                <PostSearch onSearch={results => setPosts(results)} />
                {posts.map((post) => (
                    <div key={post.id}>
                        <img src={post.imageUrl} alt={post.title} />
                        <p>
                            <strong>{post.title}</strong>
                        </p>
                        <p>{post.caption}</p>
                    </div>
                ))}

            </div>
            {/* <button onClick={() => console.log('I hath been clicked!')}>Click here!</button> */}
        </div>
    );
};


// const PostList = () => {
//     const [posts, setPosts] = useState([]);

//     useEffect(() => {
//         fetch('/api/posts')
//             .then(res => res.json())
//             .then(data => setPosts(data));
//     }, []);

//     return (
//         <div className="container">
//             <div className="row justify-content-center">
//                 {/* <div className=""> */}
//                 {posts.map((post) => (
//                     <div key={post.id}>
//                         <img src={post.imageUrl} alt={post.title} />
//                         <p>
//                             <strong>{post.title}</strong>
//                         </p>
//                         <p>{post.caption}</p>
//                     </div>
//                 ))}
//             </div>
//         </div>
//     );
// };

export default PostList;