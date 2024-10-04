export const tableOfContentsModule = (function() {
  function createSubjectLink(subject, currentSubjectId) {
    const subjectLink = document.createElement('a');
    subjectLink.href = `/Subject/${subject.id}`;
    subjectLink.className = 'block hover:bg-gray-100 p-2 rounded';
    if (currentSubjectId !== null && subject.id === parseInt(currentSubjectId)) {
      subjectLink.className += ' font-bold';
    }
    subjectLink.textContent = subject.headline;
    return subjectLink;
  }

  function createExerciseList(exercises, currentExerciseId) {
    const exerciseList = document.createElement('ul');
    exerciseList.className = 'ml-4 space-y-1 mt-1';
    exercises.forEach(exercise => {
      const exerciseItem = document.createElement('li');
      const exerciseLink = document.createElement('a');
      exerciseLink.href = `/Exercise/${exercise.id}`;
      exerciseLink.className = 'text-sm text-gray-600 hover:text-gray-900';
      if (currentExerciseId !== null && exercise.id === parseInt(currentExerciseId)) {
        exerciseLink.className += ' font-bold';
      }
      exerciseLink.textContent = exercise.headline;
      exerciseItem.appendChild(exerciseLink);
      exerciseList.appendChild(exerciseItem);
    });
    return exerciseList;
  }

  function buildTableOfContents(course, currentSubjectId, currentExerciseId) {
    const tableOfContents = document.createElement('div');
    let allItems = [];
    let currentIndex = -1;

    course.subjects.forEach((subject, index) => {
      const subjectLink = createSubjectLink(subject, currentSubjectId);
      tableOfContents.appendChild(subjectLink);

      allItems.push({ type: 'subject', id: subject.id });

      if (currentSubjectId !== null && subject.id === parseInt(currentSubjectId)) {
        currentIndex = allItems.length - 1;
      }

      if (subject.exercises && subject.exercises.length > 0) {
        const exerciseList = createExerciseList(subject.exercises, currentExerciseId);
        tableOfContents.appendChild(exerciseList);

        subject.exercises.forEach(exercise => {
          allItems.push({ type: 'exercise', id: exercise.id });
          if (currentExerciseId !== null && exercise.id === parseInt(currentExerciseId)) {
            currentIndex = allItems.length - 1;
          }
        });
      }
    });

    return { tableOfContentsElement: tableOfContents, allItems, currentIndex };
  }

  function setupNavigationButtons(prevButton, nextButton, allItems, currentIndex) {
    if (currentIndex > 0) {
      const prevItem = allItems[currentIndex - 1];
      prevButton.onclick = () => {
        window.location.href = prevItem.type === 'subject' ? `/Subject/${prevItem.id}` : `/Exercise/${prevItem.id}`;
      };
      prevButton.classList.remove('invisible');
    } else {
      prevButton.classList.add('invisible');
    }

    if (currentIndex < allItems.length - 1) {
      const nextItem = allItems[currentIndex + 1];
      nextButton.onclick = () => {
        window.location.href = nextItem.type === 'subject' ? `/Subject/${nextItem.id}` : `/Exercise/${nextItem.id}`;
      };
      nextButton.classList.remove('invisible');
    } else {
      nextButton.classList.add('invisible');
    }
  }

  async function fetchCourseData(courseId) {
    const response = await fetch(`/api/Courses/${courseId}`);
    if (!response.ok) {
      throw new Error('Failed to fetch course data');
    }
    return await response.json();
  }

  async function loadTableOfContents(courseId, currentSubjectId, currentExerciseId) {
    try {
      if (courseId === null) {
        throw new Error('Course ID is not provided');
      }

      const course = await fetchCourseData(courseId);
      const tableOfContentsContainer = document.getElementById('tableOfContents');
      const { tableOfContentsElement, allItems, currentIndex } = buildTableOfContents(course, currentSubjectId, currentExerciseId);

      tableOfContentsContainer.innerHTML = '';
      tableOfContentsContainer.appendChild(tableOfContentsElement);

      const prevButton = document.getElementById('prevButton');
      const nextButton = document.getElementById('nextButton');
      setupNavigationButtons(prevButton, nextButton, allItems, currentIndex);

    } catch (error) {
      console.error('Error loading table of contents:', error);
    }
  }

  return {
    loadTableOfContents,
    createSubjectLink,
    createExerciseList,
    buildTableOfContents,
    setupNavigationButtons,
    fetchCourseData
  };
})();
